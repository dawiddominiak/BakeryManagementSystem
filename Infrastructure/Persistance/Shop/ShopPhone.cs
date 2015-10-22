using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Persistance.Shop
{
    public class ShopPhone
    {
        [Key]
        public string Number { get; set; }
        public Shop Shop { get; set; }
    }
}
