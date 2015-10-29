using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Persistance.Context.Shop
{
    public class Owner
    {
        [Key]
        public Guid Id { get; set; }

        [Index(IsUnique = true)]
        [Column("Code", Order = 1, TypeName = "varchar")]
        public string Code { get; set; }
        public string Name { get; set; }
        public string TaxIdentificationNumber { get; set; }
        public string NationalEconomyRegister { get; set; }
        public OwnerAddress OwnerAddress { get; set; }
        public ICollection<OwnerPhone> Phones { get; set; }
        public ICollection<Shop> Shops { get; set; } 
    }
}
