using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Domain.Shop
{
    public class Owner : IEntity<Owner>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string TaxIdentificationNumber { get; set; }
        public string NationalEconomyRegister { get; set; }
        public Shared.Structs.Address Address { get; set; }
        public List<Shared.Structs.Phone> Phones { get; private set; }

        //TODO: finished here

        public bool SameIdentityAs(Owner other)
        {
            throw new NotImplementedException();
        }
    }
}
