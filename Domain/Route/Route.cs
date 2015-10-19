using System.Collections.Generic;
using Domain.ProductMaps;
using Domain.Shop;
using Shared;

namespace Domain.Route
{
    class Route : IEntity<Route>
    {
        public RouteName RouteName { get; private set; }
        public SortedList<ShopCode, Shop.Shop> Shops { get; private set; } //Value - because it's a list of entities
        public PriceLists.PriceList RoutePriceList { get; set; }
        public List<RouteWorkday> Workdays { get; private set; } 

        public Route(RouteName routeName)
        {
            RouteName = routeName;
            Shops = new SortedList<ShopCode, Shop.Shop>();
            Workdays = new List<RouteWorkday>();
        }

        public bool SameIdentityAs(Route other)
        {
            return RouteName.Equals(other.RouteName);
        }
    }
}
