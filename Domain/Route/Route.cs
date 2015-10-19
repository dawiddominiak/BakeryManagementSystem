using System;
using System.Collections.Generic;
using Domain.PriceLists;
using Domain.ProductMaps;
using Domain.Shop;
using Shared;
using Shared.Structs;

namespace Domain.Route
{
    public class Route : IEntity<Route>
    {
        public RouteName RouteName { get; private set; }
        public SortedList<DateTimePeriod, Shop.Shop> Shops { get; private set; } 
        public SortedList<DateTime, PriceList> RoutePriceLists { get; private set; }
        public List<RouteWorkday> Workdays { get; private set; } 

        public Route(RouteName routeName)
        {
            RouteName = routeName;
            Shops = new SortedList<DateTimePeriod, Shop.Shop>();
            Workdays = new List<RouteWorkday>();
            RoutePriceLists = new SortedList<DateTime, PriceList>();
        }

        public bool SameIdentityAs(Route other)
        {
            return RouteName.Equals(other.RouteName);
        }
    }
}
