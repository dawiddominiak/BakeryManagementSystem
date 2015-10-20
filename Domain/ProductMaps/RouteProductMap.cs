using System;

namespace Domain.ProductMaps
{
    public class RouteProductMap : ProductMap
    {
        public RouteProductMapType Type { get; private set; }
        public Route.Route Route { get; private set; }
        public DateTime ApplicationDate { get; set; }

        public RouteProductMap(ProductMapId id, Route.Route route, RouteProductMapType type) : base(id)
        {
            Type = type;
            Route = route;
        }
    }
}
