using System.Collections.Generic;
using Shared;
using Shared.Structs;

namespace Domain.PriceLists
{
    public class PriceList<TK> 
        : IEntity<PriceList<TK>>, IAggregateRoot
    {
        public PriceListId Id { get; set; }
        public TK Seller { get; set; }
        public DateTimePeriod ApplicationPeriod { get; set; }
        public Dictionary<Assortment.Product, Money> Prices { get; set; }

        public PriceList(PriceListId id)
        {
            Id = id;
            Prices = new Dictionary<Assortment.Product, Money>();
        }

        public static Money operator *(PriceList<TK> priceList, ProductMaps.ProductMap map)
        {
            var money = new Money(0m);
         
            if (map.Products.Count == 0)
            {
                return money;
            }

            foreach(var productPair in map.Products)
            {
                Money productPrice;
                    
                if(!priceList.Prices.TryGetValue(productPair.Key, out productPrice))
                {

                    throw new Shared.Exceptions.MissingProductsInPriceListException();
                }

                money += productPair.Value * productPrice;
            }

            return money;
        }

        public static Money operator *(ProductMaps.ProductMap map, PriceList<TK> priceList)
        {
            return priceList * map;
        }

        public bool SameIdentityAs(PriceList<TK> other)
        {
            return Id.Equals(other.Id);
        }
    }
}
