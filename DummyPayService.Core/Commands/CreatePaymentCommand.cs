using DummyPayService.Core.DataContracts;
using MediatR;

namespace DummyPayService.Core.Commands
{
    public class CreatePaymentCommand : IRequest<TResult<PaymentTransaction>>
    {
        public CreatePaymentRequestParameter CreatePaymentRequestParameter { get; }

        public CreatePaymentCommand(CreatePaymentRequestParameter requestParameter)
        {
            CreatePaymentRequestParameter = requestParameter;
        }
    }
}