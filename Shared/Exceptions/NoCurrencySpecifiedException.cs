using System;

namespace Shared.Exceptions
{
    public class NoCurrencySpecifiedException : Exception
    {
        public NoCurrencySpecifiedException()
        { }

        public NoCurrencySpecifiedException(string message) 
            : base(message)
        { }

        public NoCurrencySpecifiedException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}
