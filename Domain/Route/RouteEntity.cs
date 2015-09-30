using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Route
{
    class RouteEntity
    {
        public string Name { get; set; }
        public ProductMaps.RouteWarehouseIssueProductMap WarehouseIssue { get; set; }
        public ProductMaps.RouteIssuedGoodsProductMap IssuedGoods { get; set; }
        public ProductMaps.RouteReturnedGoodsProductMap ReturnedGoods { get; set; }
        public ProductMaps.RouteReturnedReturnsProductMap ReturnedReturns { get; set; }
        public List<Shop.ShopEntity> Shops { get; set; }
        public PriceLists.RoutePriceList RoutePriceList { get; set; }

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


    }
}
