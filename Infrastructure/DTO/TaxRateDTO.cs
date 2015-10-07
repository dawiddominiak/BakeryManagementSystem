using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class TaxRateDTO : DTO
    {
        public TaxRateDTO() : base() { }
        
        public decimal Rate { get; set; }
    }
}
