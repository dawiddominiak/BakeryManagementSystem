using System;

namespace Domain.Route
{
    public struct RouteId : IEquatable<RouteId>
    {
        public Guid Id { get; private set; }

        public RouteId(Guid id) : this()
        {
            Id = id;
        }

        public static RouteId FromString(string uuid)
        {
            return new RouteId(new Guid(uuid));
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        bool IEquatable<RouteId>.Equals(RouteId other)
        {
            return Id.ToString() == other.Id.ToString();
        }
    }
}
