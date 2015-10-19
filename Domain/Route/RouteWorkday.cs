using System;
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
        
        public RouteWorkday(DateTime date, ProductMap warehouseIssue, ProductMap issuedGoods, ProductMap returnedGoods, ProductMap returnedReturns) : this()
        {
            Date = date;
            WarehouseIssue = warehouseIssue;
            IssuedGoods = issuedGoods;
            ReturnedGoods = returnedGoods;
            ReturnedReturns = returnedReturns;
        }

        public bool Equals(RouteWorkday other)
        {
            return Date.Date.Equals(other.Date.Date) &&
                   WarehouseIssue.Equals(other.WarehouseIssue) &&
                   IssuedGoods.Equals(other.IssuedGoods) &&
                   ReturnedGoods.Equals(other.ReturnedGoods) &&
                   ReturnedReturns.Equals(other.ReturnedReturns);
        }
    }
}
