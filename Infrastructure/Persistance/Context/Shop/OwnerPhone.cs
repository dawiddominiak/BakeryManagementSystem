using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Persistance.Context.Shop
{
    public class OwnerPhone : IEquatable<OwnerPhone>
    {
        public Owner Owner { get; set; }

        public Guid OwnerId { get; set; }

        [Key, Column(Order = 0)]
        public string Country { get; set; }
        
        [Key, Column(Order = 1)]
        public string Area { get; set; }
        
        [Key, Column(Order = 2)]
        public string Number { get; set; }

        public bool Equals(OwnerPhone other)
        {
            return Country == other.Country &&
                   Area == other.Area &&
                   Number == other.Number;
        }
    }
}
