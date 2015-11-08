using System;
using System.Collections.Generic;
using Domain.Shop;

namespace Infrastructure.Persistance.Repository
{
    public class ShopRepository : IShopRepository
    {
        public Shop Get(ShopId id)
        {
            throw new NotImplementedException();
        }

        public Shop GetByCode(string code)
        {
            throw new NotImplementedException();
        }

        public List<Shop> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(Shop shop)
        {
            throw new NotImplementedException();
        }

        public void Remove(Shop shop)
        {
            throw new NotImplementedException();
        }

        public ShopId NextShopId()
        {
            return new ShopId(Guid.NewGuid());
        }
    }
}
