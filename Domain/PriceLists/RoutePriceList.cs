namespace Domain.PriceLists
{
    public class RoutePriceList : AbstractPriceList
    {
        public RoutePriceList(PriceListId priceListId) : base(priceListId)
        {
            PriceType = PriceTypes.Route;
        }
    }
}
