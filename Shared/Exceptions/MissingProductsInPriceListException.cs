using System;
using System.Runtime.Serialization;

namespace Shared.Exceptions
{
    public class MissingProductsInPriceListException : BusinessLogicException
    {
        public MissingProductsInPriceListException()
        { }

        public MissingProductsInPriceListException(string message) 
            : base(message)
        { }

        public MissingProductsInPriceListException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}