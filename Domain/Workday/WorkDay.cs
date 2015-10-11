using System.Collections.Generic;
using Shared;

namespace Domain.Workday
{
    class WorkDay : IEntity<WorkDay>
    {
        public Date Date { get; private set; }
        public List<Route.Route> Routes { get; private set; }

        public WorkDay(Date date)
        {
            Date = date;
            Routes = new List<Route.Route>();
        }

        public bool SameIdentityAs(WorkDay other)
        {
            return Date.SameValueAs(other.Date);
        }
    }
}
