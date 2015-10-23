using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Persistance.ShopProductMap
{
    public class ShopProductMapProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal TaxRate { get; set; }
        public int Count { get; set; }
        public ShopProductMap ShopProductMap { get; set; }
    }
}
