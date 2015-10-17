using System.Collections.Generic;
using Shared;
using Shared.Structs;

namespace Domain.Shop
{
    public class Owner : IEntity<Owner>
    {
        public OwnerCode Code { get; private set; }
        public string Name { get; set; }
        public string TaxIdentificationNumber { get; set; }
        public string NationalEconomyRegister { get; set; }
        public Address Address { get; set; }
        public List<Phone> Phones { get; private set; }

        public Owner(OwnerCode code)
        {
            Code = code;
            Phones = new List<Phone>();
        }

        public bool SameIdentityAs(Owner other)
        {
            return Code.Equals(other.Code);
        }
    }
}
