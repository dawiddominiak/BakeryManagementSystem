using System;
using System.Runtime.InteropServices;

namespace Domain.ProductMaps.Exceptions
{
    [ComVisible(true)]
    [Serializable]
    public class WrongRouteProductMapTypeException : ArgumentException
    {
        public WrongRouteProductMapTypeException(string message)
            : base(message)
        {
        }

        public WrongRouteProductMapTypeException(string message, Exception e)
            : base(message, e)
        {
        }

        public WrongRouteProductMapTypeException(string message, string paramName)
            : base(message, paramName)
        {
        }

        public WrongRouteProductMapTypeException(string message, string paramName, Exception e)
            : base(message, paramName, e)
        {
        }
    }
}
