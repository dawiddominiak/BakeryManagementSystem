using System.Collections.Generic;
using Domain.ProductMaps;
using Shared;

namespace Domain.Route
{
    class Route : IEntity<Route>
    {
        public RouteId RouteId { get; private set; }
        public string Name { get; set; }
        public ProductMap WarehouseIssue { get; set; }
        public ProductMap IssuedGoods { get; set; }
        public ProductMap ReturnedGoods { get; set; }
        public ProductMap ReturnedReturns { get; set; }
        public List<Shop.Shop> Shops { get; private set; }
        public PriceLists.PriceList RoutePriceList { get; set; }

        public Route(RouteId routeId)
        {
            RouteId = routeId;
            Shops = new List<Shop.Shop>();
        }

        /*public Dictionary<Product.ProductEntity, int> CalculateDirectGoodsSell()
        {
            var directGoodsSell = new Dictionary<Product.ProductEntity, int>();
            
            foreach(KeyValuePair<Product.ProductEntity, int> warehouseGoodAmount in WarehouseIssue.Products)
            {
                int issuedGoodAmount;
                int returnedGoodAmount;
                
                if(!IssuedGoods.Products.TryGetValue(warehouseGoodAmount.Key, out issuedGoodAmount)) 
                {
                    issuedGoodAmount = 0;
                }

                if (!ReturnedGoods.Products.TryGetValue(warehouseGoodAmount.Key, out returnedGoodAmount))
                {
                    returnedGoodAmount = 0;
                }

                directGoodsSell.Add(warehouseGoodAmount.Key, warehouseGoodAmount.Value - issuedGoodAmount - returnedGoodAmount);
            }

            return directGoodsSell;
        }*/



        public bool SameIdentityAs(Route other)
        {
            return RouteId.Equals(other.RouteId);
        }
    }
}
