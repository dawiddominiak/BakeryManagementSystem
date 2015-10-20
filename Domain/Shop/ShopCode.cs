using System;

namespace Domain.Shop
{
    public struct ShopCode : IEquatable<ShopCode>
    {
        public string Code { get; private set; }

        public ShopCode(string code) : this()
        {
            Code = code;
        }

        public bool Equals(ShopCode other)
        {
            return Code == other.Code;
        }
    }
}
