using System;

namespace Domain.Product
{
    public struct ProductCode : IEquatable<ProductCode>
    {
        public string Code { get; private set; }

        public ProductCode(string code) : this()
        {
            Code = code;
        }

        public bool Equals(ProductCode other)
        {
            return Code == other.Code;            
        }
    }
}
