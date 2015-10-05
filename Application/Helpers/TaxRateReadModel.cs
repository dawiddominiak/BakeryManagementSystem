using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    class TaxRateReadModel
    {
        public void save(Domain.Product.TaxRate taxRate)
        {
            var taxRateDTO = new Infrastructure.DTO.TaxRateDTO
            {
                Rate = taxRate.Rate
            };
        }
    }
}
