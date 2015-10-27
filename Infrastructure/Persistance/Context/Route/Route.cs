using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Persistance.Context.PriceList.Route;
using Infrastructure.Persistance.Context.ProductMap.Route;

namespace Infrastructure.Persistance.Context.Route
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
