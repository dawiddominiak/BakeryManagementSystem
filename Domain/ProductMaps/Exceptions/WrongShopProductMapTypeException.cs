using System;
using System.Runtime.InteropServices;

namespace Domain.ProductMaps.Exceptions
{
    [ComVisible(true)]
    [Serializable]
    public class WrongShopProductMapTypeException : ArgumentException
    {
        public WrongShopProductMapTypeException(string message)
            : base(message)
        {
        }

        public WrongShopProductMapTypeException(string message, Exception e)
            : base(message, e)
        {
        }

        public WrongShopProductMapTypeException(string message, string paramName)
            : base(message, paramName)
        {
        }

        public WrongShopProductMapTypeException(string message, string paramName, Exception e)
            : base(message, paramName, e)
        {
        }
    }
}
