using System.Collections.Generic;

namespace Domain.PriceLists
{
    public interface IPriceListRepository
    {
        PriceList Get(PriceListId id);
        List<PriceList> GetAll();
        void Save(PriceList priceList);
        PriceListId GetNextId();
    }
}
