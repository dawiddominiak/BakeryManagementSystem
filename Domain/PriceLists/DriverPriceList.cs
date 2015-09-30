using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PriceLists
{
    class DriverPriceList : AbstractPriceListEntity
    {
        public DriverPriceList()
        {
            PriceType = PriceTypes.Gross;
        }
    }
}
