using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.RouteShop
{
    public class RouteShop
    {
        public string RouteName { get; set; }
        public string ShopCode { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Route.Route Route { get; set; }
        public Shop.Shop Shop { get; set; }
    }
}
