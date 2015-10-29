using System;
using Shared;

namespace Domain.Shop
{
    public class OwnerId : GuidId
    {
        public OwnerId(Guid id) : base(id)
        {
        }

        public OwnerId(string id) : base(id)
        {
        }
    }
}
