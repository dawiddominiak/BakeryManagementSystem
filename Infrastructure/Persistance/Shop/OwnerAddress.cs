using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Persistance.Shop
{
    public class OwnerAddress
    {
        [Key, ForeignKey("Owner")]
        public string OwnerCode { get; set; }
        
        public Owner Owner { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
