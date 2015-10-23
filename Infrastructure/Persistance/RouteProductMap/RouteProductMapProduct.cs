using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Persistance.RouteProductMap
{
    public class RouteProductMapProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal TaxRate { get; set; }
        public int Count { get; set; }
        public RouteProductMap RouteProductMap { get; set; }
    }
}
