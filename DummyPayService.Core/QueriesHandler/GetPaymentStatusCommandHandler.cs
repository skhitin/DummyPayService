using System;
using System.Threading;
using System.Threading.Tasks;
using DummyPayService.Core.DataContracts;
using DummyPayService.Domain;
using MediatR;

namespace DummyPayService.Core.Commands
{
    public class GetPaymentStatusCommandHandler : IRequestHandler<GetPaymentStatusCommand, TResult<string>>
    {
        private readonly IBankEmitentClient _bankEmitentClient;

        public GetPaymentStatusCommandHandler(IBankEmitentClient bankEmitentClient)
        {
            _bankEmitentClient = bankEmitentClient ?? throw new ArgumentNullException(nameof(bankEmitentClient));
        }

        public async Task<TResult<string>> Handle(GetPaymentStatusCommand request, CancellationToken cancellationToken)
        {
            if (request?.TransactionId == Guid.Empty)
            {
                throw new ArgumentNullException("TransactionId is empty");
            }

            var paymentStatus = await _bankEmitentClient.GetPaymentStatusAsync(request.TransactionId);
            return new TResult<string>
            {
                Result = paymentStatus.ToString()
            };
        }
    }
}