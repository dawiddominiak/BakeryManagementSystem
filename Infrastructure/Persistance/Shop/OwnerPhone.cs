using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Persistance.Shop
{
    public class OwnerPhone
    {
        [Key]
        public string Number { get; set; }
        public Owner Owner { get; set; }
    }
}
