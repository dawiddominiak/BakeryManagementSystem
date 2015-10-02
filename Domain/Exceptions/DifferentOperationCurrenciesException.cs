using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    [Serializable]
    public class DifferentOperationCurrenciesException : Exception, ISerializable
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
