using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Persistance.Context.PriceList
{
    public abstract class PriceListProducts<TK>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Amount { get; set; }
        public TK PriceList { get; set; }
    }
}
