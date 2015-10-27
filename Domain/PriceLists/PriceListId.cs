using System;

namespace Domain.PriceLists
{
    public struct PriceListId : IEquatable<PriceListId>
    {
        public Guid Id { get; set; }

        public PriceListId(Guid id)
            : this()
        {
            Id = id;
        }

        public static PriceListId FromString(string id)
        {
            return new PriceListId(new Guid(id));
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public bool Equals(PriceListId other)
        {
            return Id.ToString() == other.Id.ToString();
        }
    }
}
