using System;

namespace Domain.Assortment
{
    public struct AssortmentId : IEquatable<AssortmentId>
    {
        public Guid Id { get; private set; }

        public AssortmentId(Guid id)
            : this()
        {
            Id = id;
        }

        public static AssortmentId FromString(string id)
        {
            return new AssortmentId(new Guid(id));
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public bool Equals(AssortmentId other)
        {
            return Id.ToString() == other.Id.ToString();
        }
    }
}
