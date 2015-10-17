using System;
using Shared;

namespace Domain.Shop
{
    public struct OwnerCode : IEquatable<OwnerCode>
    {
        public string Code { get; private set; }

        public OwnerCode(string code) : this()
        {
            Code = code;
        }

        bool IEquatable<OwnerCode>.Equals(OwnerCode other)
        {
            return Code == other.Code;            
        }
    }
}
