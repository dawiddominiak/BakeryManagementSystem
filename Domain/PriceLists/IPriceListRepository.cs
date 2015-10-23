using System.Collections.Generic;

namespace Domain.PriceLists
{
    public interface IPriceListRepository<TK>
    {
        PriceList<TK> Get(PriceListId id);
        List<PriceList<TK>> GetAll();
        void Save(PriceList<TK> priceList);
        PriceListId GetNextId();
    }
}
