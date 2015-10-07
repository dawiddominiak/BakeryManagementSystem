﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exceptions
{
    [Serializable]
    public class BusinessLogicException : Exception, ISerializable
    {
        public BusinessLogicException()
        { }

        public BusinessLogicException(string message) 
            : base(message)
        { }

        public BusinessLogicException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}