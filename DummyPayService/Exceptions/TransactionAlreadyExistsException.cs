using System;

namespace DummyPayService.Exceptions
{
    public class TransactionAlreadyExistsException : Exception
    {
        public TransactionAlreadyExistsException(): base()
        {

        }
        
        public TransactionAlreadyExistsException(string message): base(message)
        {

        }

        public TransactionAlreadyExistsException(string message, Exception exception): base(message, exception)
        {

        }
    }
}
