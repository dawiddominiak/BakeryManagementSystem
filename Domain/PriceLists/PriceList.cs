using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Shared.Structs;

namespace Domain.PriceLists
{
    public struct PriceList : IEquatable<PriceList>
    {
        public ImmutableDictionary<Product.Product, Money> Prices { get; private set; }

        public PriceList(Dictionary<Product.Product, Money> prices) : this()
        {
            Prices = prices.ToImmutableDictionary();
        }

        public static Money operator *(PriceList priceList, ProductMaps.ProductMap map)
        {
            if (priceList.Prices.IsEmpty)
            {
                return new Money(0m);
            }

            Money money = new Money(0m);

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

        public static Money operator *(ProductMaps.ProductMap map, PriceList priceList)
        {
            return priceList * map;
        }

        public bool Equals(PriceList other)
        {

            if (Prices == null && other.Prices == null)
            {
                return true;
            }

            if (Prices == null || other.Prices == null)
            {
                return false;
            }

            if (Prices.Keys == null && other.Prices.Keys == null)
            {
                return true;
            }

            if (Prices.Keys == null || other.Prices.Keys == null)
            {
                return false;
            }

            if (Prices.Count != other.Prices.Count ||
                Prices.Keys.Except(other.Prices.Keys).Any() ||
                other.Prices.Keys.Except(Prices.Keys).Any())
            {
                return false;
            }

            return Prices.All(pair => pair.Value == other.Prices[pair.Key]);
        }
    }
}
