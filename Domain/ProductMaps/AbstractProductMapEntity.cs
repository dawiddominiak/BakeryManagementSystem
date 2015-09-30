using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProductMaps
{
    public abstract class AbstractProductMapEntity
    {
        public Dictionary<Product.ProductEntity, int> Products { get; set; }
    }
}
