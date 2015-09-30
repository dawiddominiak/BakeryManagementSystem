using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PriceLists
{
    public abstract class AbstractPriceListEntity
    {
        public Dictionary<Product.ProductEntity, Shared.Money> PriceList;
        public PriceTypes PriceType { get; protected set; }
    }
}
