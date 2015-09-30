using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PriceLists
{
    class RoutePriceList : AbstractPriceListEntity
    {
        public RoutePriceList()
        {
            PriceType = PriceTypes.Route;
        }
    }
}
