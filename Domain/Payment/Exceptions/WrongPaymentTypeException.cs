using System;
using System.Runtime.InteropServices;

namespace Domain.Payment.Exceptions
{
    [ComVisible(true)]
    [Serializable]
    public class WrongPaymentTypeException : ArgumentException
    {
        public WrongPaymentTypeException(string message)
            : base(message)
        {
        }

        public WrongPaymentTypeException(string message, Exception e)
            : base(message, e)
        {
        }

        public WrongPaymentTypeException(string message, string paramName)
            : base(message, paramName)
        {
        }

        public WrongPaymentTypeException(string message, string paramName, Exception e)
            : base(message, paramName, e)
        {
        }
    }
}
