using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Persistance.Shop
{
    public class Owner
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public string TaxIdentificationNumber { get; set; }
        public string NationalEconomyRegister { get; set; }
        public ICollection<OwnerPhone> Phones { get; set; }
        public OwnerAddress OwnerAddress { get; set; }
        public ICollection<Shop> Shops { get; set; } 
    }
}
