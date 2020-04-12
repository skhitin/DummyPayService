using DummyPayService.Core.CommandHandlers;
using DummyPayService.Core.Commands;
using DummyPayService.Domain;
using NSubstitute;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DummyPayService.UnitTests
{
    public class ConfirmPaymentCommandHandlerShould
    {
        private readonly IBankEmitentClient _bankEmitentClient = Substitute.For<IBankEmitentClient>();

        private ConfirmPaymentCommandHandler _handler;

        public ConfirmPaymentCommandHandlerShould()
        {
            _handler = new ConfirmPaymentCommandHandler(_bankEmitentClient);
        }

        [Fact]
        public async Task ThrowArgumentNullExceptionIfConfirmPaymentRequestParameterIsNullWhenHandle()
        {
            var command = new ConfirmPaymentCommand(null);
            await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
