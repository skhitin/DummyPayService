using DummyPayService.Core.Commands;
using DummyPayService.Core.DataContracts;
using DummyPayService.Core.Extrensions;
using DummyPayService.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using PaymentTransaction = DummyPayService.Core.DataContracts.PaymentTransaction;

namespace DummyPayService.Core.CommandHandlers
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, TResult<PaymentTransaction>>
    {
        private readonly IBankEmitentClient _bankEmitentClient;

        public CreatePaymentCommandHandler(IBankEmitentClient bankEmitentClient)
        {
            _bankEmitentClient = bankEmitentClient ?? throw new ArgumentNullException(nameof(bankEmitentClient));
        }

        public async Task<TResult<PaymentTransaction>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            if (request?.CreatePaymentRequestParameter == null)
            {
                throw new ArgumentNullException($"Parameters for creation payment not found");
            }

            var transaction = await _bankEmitentClient.PaymentIntentionAsync(request.CreatePaymentRequestParameter.ToPayment());
            return new TResult<PaymentTransaction>
            {
                Result = transaction.ToPaymentTransaction()
            };
        }
    }
}
