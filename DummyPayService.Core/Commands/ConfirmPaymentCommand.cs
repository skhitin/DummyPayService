using DummyPayService.Core.DataContracts;
using MediatR;

namespace DummyPayService.Core.Commands
{
    public class ConfirmPaymentCommand : IRequest<TResult<ConfirmPaymentTransaction>>
    {
        public ConfirmPaymentRequestParameter ConfirmPaymentRequestParameter { get; }

        public ConfirmPaymentCommand(ConfirmPaymentRequestParameter requestParameter)
        {
            ConfirmPaymentRequestParameter = requestParameter;
        }
    }
}