using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PriceLists
{
    public class RoutePriceList : AbstractPriceListEntity
    {
        public RoutePriceList()
        {
            PriceType = PriceTypes.Route;
        }
    }
}
