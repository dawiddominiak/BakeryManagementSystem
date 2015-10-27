using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Persistance.Context.ProductMap
{
    public abstract class ProductMap<TK, TV, TL>
    {
        [Key]
        public Guid Id { get; set; }
        public ICollection<TV> Products { get; set; }
        public TL ProductMapType { get; set; }
        public DateTime ApplicationDate { get; set; }
        public TK Seller { get; set; }
    }
}
