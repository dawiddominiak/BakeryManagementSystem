using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    [Serializable]
    class NumberOfProductsLowerThanZeroException : BusinessLogicException, ISerializable
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
