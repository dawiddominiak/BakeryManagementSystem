using System.Collections.Generic;
using Shared;
using Shared.Structs;

namespace Domain.Route
{
    public class Route : IEntity<Route>, ISeller
    {
        public RouteName RouteName { get; private set; }
        public SortedList<DateTimePeriod, Shop.Shop> Shops { get; private set; } 

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
