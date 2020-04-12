using DummyPayService.Core.DataContracts;
using MediatR;
using System;

namespace DummyPayService.Core.Commands
{
    public class GetPaymentStatusCommand : IRequest<TResult<string>>
    {
        public Guid TransactionId { get; }

        public GetPaymentStatusCommand(Guid transactionId)
        {
            TransactionId = transactionId;
        }
    }
}