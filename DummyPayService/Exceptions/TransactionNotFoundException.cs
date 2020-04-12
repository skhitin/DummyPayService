using System;

namespace DummyPayService.Exceptions
{
    public class TransactionNotFoundException : Exception
    {
        public TransactionNotFoundException(): base()
        {

        }
        
        public TransactionNotFoundException(string message): base(message)
        {

        }

        public TransactionNotFoundException(string message, Exception exception): base(message, exception)
        {

        }
    }
}
