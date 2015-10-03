using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shop
{
    public class OwnerEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string TaxIdentificationNumber { get; set; }
        public string NationalEconomyRegister { get; set; }
        public Application.Shared.Address Address { get; set; }
        public List<Application.Shared.Phone> Phones { get; private set; }
    }
}
