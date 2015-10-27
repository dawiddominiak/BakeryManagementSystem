using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Persistance.Context.PriceList
{
    public abstract class PriceList<TK, TV>
    {
        [Key]
        public Guid Id { get; set; }
        public TK Seller { get; set; }
        public DateTime ApplicationPeriodFrom { get; set; }
        public DateTime ApplicationPeriodTo { get; set; }
        public ICollection<TV> Products { get; set; }
    }
}
