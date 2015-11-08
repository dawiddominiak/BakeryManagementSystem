using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Persistance.Context.PriceList.Shop;
using Infrastructure.Persistance.Context.ProductMap.Shop;

namespace Infrastructure.Persistance.Context.Shop
{
    public class Shop
    {
        [Key]
        public Guid Id { get; set; }

        [Index(IsUnique = true)]
        [Column("Shop", Order = 1, TypeName = "varchar")]
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Removed { get; set; } = false;
        public Owner Owner { get; set; }

        public ICollection<Payment.Payment> Payments { get; set; }

        [Required]
        public ShopAddress ShopAddress { get; set; }

        public ICollection<ShopPhone> Phones { get; set; }
        public ICollection<RouteShop.RouteShop> RouteShops { get; set; }
        public ICollection<ShopProductMap> ShopProductMaps { get; set; }
        public ICollection<ShopPriceList> PriceLists { get; set; }
    }
}
