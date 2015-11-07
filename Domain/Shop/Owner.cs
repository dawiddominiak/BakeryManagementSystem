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
        public List<Phone> Phones { get; set; } = new List<Phone>();
        public List<Shop> Shops { get; set; } = new List<Shop>();

        public Owner()
        {}

        public Owner(OwnerId id)
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
