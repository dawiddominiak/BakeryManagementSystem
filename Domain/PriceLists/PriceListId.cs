using System;
using Shared;

namespace Domain.PriceLists
{
    public class PriceListId : IValueObject<PriceListId>
    {
        public Guid Id { get; private set; }

        public PriceListId(Guid id)
        {
            Id = id;
        }

        public static PriceListId FromString(string uuid)
        {
            return new PriceListId(new Guid(uuid));
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public bool SameValueAs(PriceListId other)
        {
            return Id.ToString() == other.Id.ToString();
        }
    }
}
