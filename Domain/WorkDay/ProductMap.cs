using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.WorkDay
{
    abstract class ProductMap
    {
        public ProductMap()
        {
            this.Products = new Dictionary<Ware.Product, int>();
        }

        public Dictionary<Domain.Ware.Product, int> Products { get; private set; }
    }
}
