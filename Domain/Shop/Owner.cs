using System.Collections.Generic;
using Shared;
using Shared.Structs;

namespace Domain.Shop
{
    public class Owner : IEntity<Owner>
    {
        public OwnerId Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string TaxIdentificationNumber { get; set; }
        public string NationalEconomyRegister { get; set; }
        public Address Address { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Shop> Shops { get; set; } 

        public Owner()
        {
            Phones = new List<Phone>();
            Shops = new List<Shop>();
        }

        public Owner(OwnerId id)
            : base()
        {
            Id = id;
        }

        public bool SameIdentityAs(Owner other)
        {
            return Id.Equals(other.Id);
        }

        public override string ToString()
        {
            return Name + " [" + Code + "]";
        }
    }
}
