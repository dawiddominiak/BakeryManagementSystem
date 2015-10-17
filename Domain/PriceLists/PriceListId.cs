using System;

namespace Domain.PriceLists
{
    public struct PriceListId : IEquatable<PriceListId>
    {
        public Guid Id { get; private set; }

        public PriceListId(Guid id) : this()
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

        bool IEquatable<PriceListId>.Equals(PriceListId other)
        {
            return Id.ToString() == other.Id.ToString();
        }
    }
}
