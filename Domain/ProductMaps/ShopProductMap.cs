using System;

namespace Domain.ProductMaps
{
    public class ShopProductMap : ProductMap
    {
        public ShopProductMapType Type { get; private set; }
        public Shop.Shop Shop { get; private set; }
        public DateTime ApplicationDate { get; set; }

        public ShopProductMap(ProductMapId id, Shop.Shop shop, ShopProductMapType type) : base(id)
        {
            Type = type;
            Shop = shop;
        }
    }
}
