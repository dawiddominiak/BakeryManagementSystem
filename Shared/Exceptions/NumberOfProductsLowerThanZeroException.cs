using System;

namespace Shared.Exceptions
{
    public class NumberOfProductsLowerThanZeroException : BusinessLogicException
    {
        public NumberOfProductsLowerThanZeroException()
        { }

        public NumberOfProductsLowerThanZeroException(string message) 
            : base(message)
        { }

        public NumberOfProductsLowerThanZeroException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}
