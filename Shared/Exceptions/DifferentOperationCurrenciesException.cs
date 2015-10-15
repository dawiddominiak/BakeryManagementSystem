using System;

namespace Shared.Exceptions
{
    public class DifferentOperationCurrenciesException : Exception
    {
        public DifferentOperationCurrenciesException()
        { }

        public DifferentOperationCurrenciesException(string message) 
            : base(message)
        { }

        public DifferentOperationCurrenciesException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}
