using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    class ProductDTO : DTO
    {
        public ProductDTO() : base() { }

        public string Code { get; set; }

        public string Name { get; set; }

        public Guid TaxRateID { get; set; }
    }
}
