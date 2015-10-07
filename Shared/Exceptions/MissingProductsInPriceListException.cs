﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exceptions
{
    [Serializable]
    public class MissingProductsInPriceListException : BusinessLogicException, ISerializable
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