using System.Collections.Generic;

namespace Domain.Shop
{
    public interface IShopRepository
    {
        Shop Get(ShopId id);
        Shop GetByCode(string code);
        List<Shop> GetAll();
        void Save(Shop shop);
        ShopId GetNextId();
    }
}
