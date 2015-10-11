using System;
using Shared;

namespace Domain.Route
{
    public class RouteId : IValueObject<RouteId>
    {
        public Guid Id { get; private set; }

        public RouteId(Guid id)
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

        public bool SameValueAs(RouteId other)
        {
            return Id.ToString() == other.Id.ToString();
        }
    }
}
