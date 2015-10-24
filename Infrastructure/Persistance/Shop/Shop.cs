﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Persistance.PriceList.Shop;
using Infrastructure.Persistance.ProductMap.Shop;

namespace Infrastructure.Persistance.Shop
{
    public class Shop
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public Owner Owner { get; set; }
        public ICollection<Payment.Payment> Payments { get; set; }
        public ShopAddress ShopAddress { get; set; }
        public ICollection<ShopPhone> ShopPhones { get; set; }
        public ICollection<RouteShop.RouteShop> RouteShops { get; set; }
        public ICollection<ShopProductMap> ShopProductMaps { get; set; }
        public ICollection<ShopPriceList> PriceLists { get; set; }
    }
}
