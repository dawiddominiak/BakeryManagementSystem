namespace Domain.PriceLists
{
    public class ShopPriceList : AbstractPriceList
    {
        public ShopPriceList(PriceListId priceListId) : base(priceListId)
        {
            PriceType = PriceTypes.Shop;
        }
    }
}
