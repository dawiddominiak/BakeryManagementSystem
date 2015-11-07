using System;
using Shared;

namespace Domain.Shop
{
    public class ShopId : GuidId
    {
        public ShopId(Guid id) : base(id)
        {
        }

        public ShopId(string id) : base(id)
        {
        }
    }
}
