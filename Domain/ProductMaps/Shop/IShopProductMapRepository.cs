using System.Collections.Generic;

namespace Domain.ProductMaps.Shop
{
    public interface IShopProductMapRepository
    {
        ShopProductMap Get(ProductMapId id);
        List<ShopProductMap> GetAll();
        void Save(ShopProductMap shopProductMap);
        ProductMapId GetNextId();
    }
}
