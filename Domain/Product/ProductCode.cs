using System;
using Shared;

namespace Domain.Product
{
    public struct ProductCode : IEquatable<ProductCode>
    {
        public string Code { get; private set; }

        public ProductCode(string code) : this()
        {
            Code = code;
        }

        bool IEquatable<ProductCode>.Equals(ProductCode other)
        {
            return Code == other.Code;            
        }
    }
}
