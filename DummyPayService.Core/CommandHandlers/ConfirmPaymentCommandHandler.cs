using DummyPayService.Core.Commands;
using DummyPayService.Core.DataContracts;
using DummyPayService.Core.Extrensions;
using DummyPayService.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DummyPayService.Core.CommandHandlers
{
    public class ConfirmPaymentCommandHandler : IRequestHandler<ConfirmPaymentCommand, TResult<ConfirmPaymentTransaction>>
    {
        private readonly IBankEmitentClient _bankEmitentClient;

        public ConfirmPaymentCommandHandler(IBankEmitentClient bankEmitentClient)
        {
            _bankEmitentClient = bankEmitentClient ?? throw new ArgumentNullException(nameof(bankEmitentClient));
        }

        public async Task<TResult<ConfirmPaymentTransaction>> Handle(ConfirmPaymentCommand request, CancellationToken cancellationToken)
        {
            if (request?.ConfirmPaymentRequestParameter == null)
            {
                throw new ArgumentNullException($"Parameters for confirmation payment not found");
            }

            var transaction = await _bankEmitentClient.CheckPaymentAsync(
                request.ConfirmPaymentRequestParameter.TransactionId, 
                request.ConfirmPaymentRequestParameter.PaRes);
            return new TResult<ConfirmPaymentTransaction>
            {
                Result = transaction.ToConfirmPaymentTransaction()
            };
        }
    }
}
