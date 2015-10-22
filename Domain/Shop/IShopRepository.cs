using System.Collections.Generic;

namespace Domain.Shop
{
    public interface IShopRepository
    {
        Shop Get(ShopCode code);
        List<Shop> GetAll();
        void Save(Shop shop);
        ShopCode GetUniqueShopCode(string proposition);
    }
}
