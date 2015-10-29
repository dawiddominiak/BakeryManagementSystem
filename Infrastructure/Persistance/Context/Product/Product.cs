using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Persistance.Context.Product
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        
        [Index(IsUnique = true)]
        [Column("Code", Order = 1, TypeName = "varchar")]
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal TaxRate { get; set; }
    }
}
