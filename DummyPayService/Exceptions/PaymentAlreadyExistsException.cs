using System;

namespace DummyPayService.Exceptions
{
    public class PaymentAlreadyExistsException : Exception
    {
        public PaymentAlreadyExistsException(): base()
        {

        }
        
        public PaymentAlreadyExistsException(string message): base(message)
        {

        }

        public PaymentAlreadyExistsException(string message, Exception exception): base(message, exception)
        {

        }
    }
}
