using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Persistance.PriceList.Route;
using Infrastructure.Persistance.ProductMap.Route;

namespace Infrastructure.Persistance.Route
{
    public class Route
    {
        [Key]
        public string Name { get; set; }
        public ICollection<RouteShop.RouteShop> RouteShops { get; set; }
        public ICollection<RouteProductMap> RouteProductMaps { get; set; }
        public ICollection<RoutePriceList> PriceLists { get; set; }
    }
}
