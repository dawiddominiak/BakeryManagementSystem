using System.Collections.Generic;

namespace Domain.Route
{
    public interface IRouteRepository
    {
        Route Get(RouteName name);
        List<Route> GetAll();
        void Save(Route route);
        RouteName GetUniqueRouteName(string proposition);
    }
}
