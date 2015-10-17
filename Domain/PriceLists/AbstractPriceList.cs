using System.Collections.Generic;
using Shared;
using Shared.Structs;

namespace Domain.PriceLists
//TODO: value from that
{
    public class AbstractPriceList : IEntity<AbstractPriceList>
    {
        public PriceListId PriceListId { get; private set; }
        public Dictionary<Product.Product, Money> PriceList { get; private set; }
        public PriceTypes PriceType { get; protected set; }

        protected AbstractPriceList(PriceListId priceListId)
        {
            PriceListId = priceListId;
            PriceList = new Dictionary<Product.Product, Money>();
        }

        public static Money operator *(AbstractPriceList priceList, ProductMaps.ProductMap map)
        {
            var money = new Money
            {
                Amount = 0,
                Currency = Currency.Pln //TODO: parametrisation
            };

            foreach(var productPair in map.Products)
            {
                Money productPrice;
                    
                if(!priceList.PriceList.TryGetValue(productPair.Key, out productPrice))
                {

                    throw new Shared.Exceptions.MissingProductsInPriceListException();
                }

                money += productPair.Value * productPrice;
            }

            return money;
        }

        public static Money operator *(ProductMaps.ProductMap map, AbstractPriceList priceList)
        {
            return priceList * map;
        }

        public bool SameIdentityAs(AbstractPriceList other)
        {
            return PriceListId.Equals(other.PriceListId);
        }
    }
}
