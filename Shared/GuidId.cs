using System;

namespace Shared
{
    public abstract class GuidId : IEquatable<GuidId>
    {
        public Guid Id { get; private set; }

        protected GuidId(Guid id)
        {
            Id = id;
        }

        protected GuidId(string id)
        {
            Id = new Guid(id);
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public bool Equals(GuidId other)
        {
            return Id.ToString() == other.Id.ToString();
        }
    }
}
