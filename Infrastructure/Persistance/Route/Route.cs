using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Route
{
    public class Route
    {
        [Key]
        public string Name { get; set; }
        public ICollection<RouteShop.RouteShop> RouteShops { get; set; }
        public ICollection<RouteProductMap.RouteProductMap> RouteProductMaps { get; set; } 
    }
}
