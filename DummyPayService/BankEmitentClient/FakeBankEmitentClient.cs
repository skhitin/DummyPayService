using DummyPayService.Domain;
using DummyPayService.Exceptions;
using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Threading.Tasks;

namespace DummyPayService.BankEmitentClient
{
    public class FakeBankEmitentClient : IBankEmitentClient
    {
        private ConcurrentDictionary<Guid, Payment> _payments { get; set; } = new ConcurrentDictionary<Guid, Payment>();
        private ConcurrentDictionary<Guid, PaymentTransaction> _transactions { get; set; } = new ConcurrentDictionary<Guid, PaymentTransaction>();

        public async Task<PaymentTransaction> PaymentIntentionAsync(Payment payment)
        {
            if (!_payments.TryAdd(payment.OrderId, payment))
            {
                throw new PaymentAlreadyExistsException($"The payment {payment.OrderId} already exists.");
            }

            var transaction = await Task.FromResult(new PaymentTransaction
            {
                TransactionId = Guid.NewGuid(),
                TransactionStatus = PaymentStatuses.Init,
                Payment = payment,
                PaReq = "MDAwMDAwMDAtMDAwMC0wMDAwLTAwMDAtMDAwMDAwMDAwMDAwREJCOTk5NDYtQTEwQS00RDFCLUE3NDItNTc3RkEwMjZCQzU3",
                Url = "http://dummypay.host/secure/",
                Method = HttpMethod.Post.Method
            });

            if (!_transactions.TryAdd(transaction.TransactionId, transaction))
            {
                throw new TransactionAlreadyExistsException($"The transaction {transaction.TransactionId} already exists.");
            }

            return transaction;
        }

        public async Task<PaymentTransaction> CheckPaymentAsync(Guid transactionId, string paRes)
        {
            if (!_transactions.TryGetValue(transactionId, out var transaction))
            {
                throw new TransactionNotFoundException($"The transaction with transactionId={transactionId} not found.");
            }

            transaction = _transactions.AddOrUpdate(transaction.TransactionId, transaction, 
                (key, oldValue) => UpdateStatus(transaction));

            return await Task.FromResult(transaction);
        }

        private PaymentTransaction UpdateStatus(PaymentTransaction transaction)
        {
            if (transaction.Payment.Card.Number.Equals("4111111111111111"))
            {
                transaction.TransactionStatus = PaymentStatuses.Approved;
            }
            else
            {
                if (transaction.Payment.Card.Number.Equals("4007702835532454"))
                {
                    transaction.TransactionStatus = PaymentStatuses.DeclinedDueToInvalidCreditCard;
                }
                else
                {
                    transaction.TransactionStatus = PaymentStatuses.Declined;
                }
            }

            return transaction;
        }

        public async Task<PaymentStatuses> GetPaymentStatusAsync(Guid transactionId)
        {
            if (!_transactions.TryGetValue(transactionId, out var transaction))
            {
                throw new TransactionNotFoundException($"The transaction with transactionId={transactionId} not found.");
            }

            return await Task.FromResult(transaction.TransactionStatus);
        }

    }
}
