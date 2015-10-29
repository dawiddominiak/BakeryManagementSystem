using System;
using Shared;

namespace Domain.Assortment
{
    public class ProductId : GuidId
    {
        public ProductId(Guid id) : base(id)
        {
        }

        public ProductId(string id) : base(id)
        {
        }
    }
}
