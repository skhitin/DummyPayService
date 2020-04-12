using DummyPayService.Core.CommandHandlers;
using DummyPayService.Core.Commands;
using DummyPayService.Domain;
using NSubstitute;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DummyPayService.UnitTests
{
    public class CreatePaymentCommandHandlerShould
    {
        private readonly IBankEmitentClient _bankEmitentClient = Substitute.For<IBankEmitentClient>();

        private CreatePaymentCommandHandler _handler;

        public CreatePaymentCommandHandlerShould()
        {
            _handler = new CreatePaymentCommandHandler(_bankEmitentClient);
        }

        [Fact]
        public async Task ThrowArgumentNullExceptionIfCreatePaymentRequestParameterIsNullWhenHandle()
        {
            var command = new CreatePaymentCommand(null);
            await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task ReturnPaymentTransactionWhenHandle()
        {
            var orderId = Guid.NewGuid();
            var requestParameters = new Core.DataContracts.CreatePaymentRequestParameter
            {
                OrderId = orderId,
                CVV = "321",
                CardExpiryDate = "1221"
            };
            var command = new CreatePaymentCommand(requestParameters);
            var paymentTransaction = new PaymentTransaction
            {
                TransactionId = Guid.NewGuid(),
                TransactionStatus = PaymentStatuses.Approved,
                Method = HttpMethod.Put.ToString(),
                Url = "url",
                PaReq = "PaReq",
            };
            _bankEmitentClient.PaymentIntentionAsync(Arg.Is<Payment>(p => p.OrderId == orderId)).Returns(paymentTransaction);

            var commandResult = await _handler.Handle(command, CancellationToken.None);

            Assert.Equal(paymentTransaction.TransactionId, commandResult.Result.TransactionId);
            Assert.Equal(paymentTransaction.TransactionStatus.ToString(), commandResult.Result.TransactionStatus);
            Assert.Equal(paymentTransaction.Method, commandResult.Result.Method);
            Assert.Equal(paymentTransaction.Url, commandResult.Result.Url);
            Assert.Equal(paymentTransaction.PaReq, commandResult.Result.PaReq);
        }
    }
}
