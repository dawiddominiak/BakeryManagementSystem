using System;
using Domain.ProductMaps.Exceptions;
using Shared;

namespace Domain.ProductMaps.Route
{
    public class RouteProductMap : ProductMap, IAggregateRoot
    {
        public RouteProductMapType Type { get; set; }
        public Domain.Route.Route Route { get; set; }
        public DateTime ApplicationDate { get; set; }

        public RouteProductMap(ProductMapId id, Domain.Route.Route route, RouteProductMapType type) : base(id)
        {
            Type = type;
            Route = route;
        }

        public RouteProductMap(ProductMapId id, Domain.Route.Route route, string type) : base(id)
        {
            RouteProductMapType rType;

            if (!Enum.TryParse(type, true, out rType))
            {
                throw new WrongRouteProductMapTypeException("Wrong route product map type.", "RouteProductMapType");
            }

            Type = rType;
            Route = route;
        }
    }
}
