﻿using Shared;

namespace Domain.Shop
{
    public class ShopCode : IValueObject<ShopCode>
    {
        public string Code { get; private set; }

        public ShopCode(string code)
        {
            Code = code;
        }

        public bool SameValueAs(ShopCode other)
        {
            return Code == other.Code;
        }
    }
}
