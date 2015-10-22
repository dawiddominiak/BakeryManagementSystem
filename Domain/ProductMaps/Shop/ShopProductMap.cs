using System;
using Domain.ProductMaps.Exceptions;
using Shared;

namespace Domain.ProductMaps.Shop
{
    public class ShopProductMap : ProductMap, IAggregateRoot
    {
        public ShopProductMapType Type { get; private set; }
        public Domain.Shop.Shop Shop { get; private set; }
        public DateTime ApplicationDate { get; set; }

        public ShopProductMap(ProductMapId id, Domain.Shop.Shop shop, ShopProductMapType type) : base(id)
        {
            Type = type;
            Shop = shop;
        }

        public ShopProductMap(ProductMapId id, Domain.Shop.Shop shop, string type) : base(id)
        {
            ShopProductMapType sType;

            if (!Enum.TryParse(type, true, out sType))
            {
                throw new WrongShopProductMapTypeException("Wrong shop product map type.", "ShopProductMapType");
            }

            Type = sType;
            Shop = shop;
        }
    }
}
