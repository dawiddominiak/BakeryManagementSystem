using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Route;
using Shared;

namespace Domain.Workday
{
    class WorkDay : IEntity<WorkDay>
    {
        public Date Date { get; private set; }
        public List<Route.RouteEntity> Routes { get; private set; }

        public WorkDay(Date date)
        {
            Date = date;
            Routes = new List<RouteEntity>();
        }

        public bool SameIdentityAs(WorkDay other)
        {
            return Date.SameValueAs(other.Date);
        }
    }
}
