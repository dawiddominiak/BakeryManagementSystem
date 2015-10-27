using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Persistance.Context.Shop
{
    public class ShopPhone
    {
        public Shop Shop { get; set; }

        [Key, Column(Order = 0)]
        public string Country { get; set; }

        [Key, Column(Order = 1)]
        public string Area { get; set; }

        [Key, Column(Order = 2)]
        public string Number { get; set; }
    }
}
