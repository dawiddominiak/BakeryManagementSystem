using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    class DifferentOperationCurrenciesException : Exception
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
