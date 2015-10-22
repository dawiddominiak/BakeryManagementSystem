using System.Collections.Generic;

namespace Domain.ProductMaps.Route
{
    public interface IRouteProductMapRepository
    {
        RouteProductMap Get(ProductMapId id);
        List<RouteProductMap> GetAll();
        void Save(RouteProductMap routeProductMap);
        ProductMapId GetNextId();
    }
}
