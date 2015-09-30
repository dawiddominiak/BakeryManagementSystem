using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PriceLists
{
    class ShopPriceList : AbstractPriceListEntity
    {
        public ShopPriceList()
        {
            PriceType = PriceTypes.Net;
        }
    }
}
