using System.Collections.Generic;
using Shared;
using Shared.Structs;

namespace Domain.Route
{
    public class Route : IEntity<Route>, ISeller, IAggregateRoot
    {
        public RouteName RouteName { get; set; }
        public SortedList<DateTimePeriod, Shop.Shop> Shops { get; set; } 

        public Route(RouteName routeName)
        {
            RouteName = routeName;
            Shops = new SortedList<DateTimePeriod, Shop.Shop>();
        }

        public bool SameIdentityAs(Route other)
        {
            return RouteName.Equals(other.RouteName);
        }
    }
}
