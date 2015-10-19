using System;
using System.Collections.Generic;
using System.Linq;
using Domain.PriceLists;
using Domain.ProductMaps;

namespace Domain.Route
{
    public struct RouteWorkday : IEquatable<RouteWorkday>
    {
        public DateTime Date { get; private set; }
        public ProductMap WarehouseIssue { get; private set; }
        public ProductMap IssuedGoods { get; private set; }
        public ProductMap ReturnedGoods { get; private set; }
        public ProductMap ReturnedReturns { get; private set; }
        public SortedList<Shop.ShopCode, Shop.Shop> Shops { get; private set; } //Value - because it's a list of entities TODO: think how to move it to Route only
        public PriceList RoutePriceList { get; private set; } //TODO: move to Route only

        public RouteWorkday(DateTime date, ProductMap warehouseIssue, ProductMap issuedGoods, ProductMap returnedGoods, ProductMap returnedReturns, PriceList routePriceList) : this()
        {
            Date = date;
            WarehouseIssue = warehouseIssue;
            IssuedGoods = issuedGoods;
            ReturnedGoods = returnedGoods;
            ReturnedReturns = returnedReturns;
            RoutePriceList = routePriceList;
        }

        public bool Equals(RouteWorkday other)
        {
            return Date.Date.Equals(other.Date.Date) &&
                   WarehouseIssue.Equals(other.WarehouseIssue) &&
                   IssuedGoods.Equals(other.IssuedGoods) &&
                   ReturnedGoods.Equals(other.ReturnedGoods) &&
                   ReturnedReturns.Equals(other.ReturnedReturns) &&
                   Shops.All(pair => pair.Value == other.Shops[pair.Key]) &&
                   RoutePriceList.Equals(other.RoutePriceList);
        }
    }
}
