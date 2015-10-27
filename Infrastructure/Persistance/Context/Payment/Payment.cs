using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Persistance.Context.Payment
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime DateTime { get; set; }
        public string PaymentType { get; set; }
        public Shop.Shop Shop { get; set; }
    }
}
