using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Persistance.Context.Shop
{
    public class OwnerAddress
    {
        [Key, ForeignKey("Owner")]
        public Guid OwnerId { get; set; }
        
        public Owner Owner { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
