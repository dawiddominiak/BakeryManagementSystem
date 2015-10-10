using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

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
