using System;
using Shared;

namespace Domain.Shop
{
    public struct ShopCode : IEquatable<ShopCode>
    {
        public string Code { get; private set; }

        public ShopCode(string code) : this()
        {
            Code = code;
        }

        bool IEquatable<ShopCode>.Equals(ShopCode other)
        {
            return Code == other.Code;
        }
    }
}
