using System.Collections.Generic;
using Domain.Shop;
using Infrastructure.Persistance.Repository;

namespace Controller.Shop
{
    public class ShopController
    {
        public Domain.Shop.Shop Get(ShopId id)
        {
            return ShopRepository.Get(id);
        }

        public Domain.Shop.Shop GetByCode(string code)
        {
            return ShopRepository.GetByCode(code);
        }

        public List<Domain.Shop.Shop> GetAll()
        {
            return ShopRepository.GetAll();
        }

        public IShopRepository ShopRepository { get; set; } = new ShopRepository();

        public void Save(Domain.Shop.Shop shop)
        {
            ShopRepository.Save(shop);
        }

        public void Remove(Domain.Shop.Shop shop)
        {
            ShopRepository.Remove(shop);
        }

        public ShopId NextShopId()
        {
            return ShopRepository.NextShopId();
        }
    }
}
