using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.ProductMaps.Shop;

namespace Infrastructure.Persistance.ShopProductMap
{
    public class ShopProductMap
    {
        [Key]
        public Guid Id { get; set; }
        public ICollection<ShopProductMapProduct> Products { get; set; }
        public ShopProductMapType ShopProductMapType { get; set; }
        public DateTime ApplicationDate { get; set; }
        public Shop.Shop Shop { get; set; }
    }
}
