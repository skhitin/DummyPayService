using DummyPayService.Domain;

namespace DummyPayService.Core.Extrensions
{
    public static class PaymentTransactionExtensions
    {
        public static DataContracts.PaymentTransaction ToPaymentTransaction(this PaymentTransaction paymentTransaction)
        {
            return new DataContracts.PaymentTransaction
            {
                TransactionId = paymentTransaction.TransactionId,
                TransactionStatus = paymentTransaction.TransactionStatus.ToString(),
                PaReq = paymentTransaction.PaReq,
                Url = paymentTransaction.Url,
                Method = paymentTransaction.Method
            };
        }

        public static DataContracts.ConfirmPaymentTransaction ToConfirmPaymentTransaction(this PaymentTransaction paymentTransaction)
        {
            return new DataContracts.ConfirmPaymentTransaction
            {
                TransactionId = paymentTransaction.TransactionId,
                Status = paymentTransaction.TransactionStatus.ToString(),
                OrderId = paymentTransaction.Payment.OrderId,
                Amount  = paymentTransaction.Payment.Amount,
                Currency = paymentTransaction.Payment.Currency,
                LastFourDigits = GetLastFourDigits(paymentTransaction.Payment.Card.Number)
            };
        }

        private static string GetLastFourDigits(string number)
        {
            return number.Substring(number.Length - 4);
        }
    }
}
