using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Workday
{
    class WorkDayEntity
    {
        public DateTime Date { get; set; }
        public List<Route.RouteEntity> Routes { get; set; }
    }
}
