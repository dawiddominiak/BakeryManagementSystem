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
        public PriceLists.DriverPriceList DriverPriceList { get; set; }

        public Shared.Money CalculateDriverSettlement()
        {
            
        }
    }
}
