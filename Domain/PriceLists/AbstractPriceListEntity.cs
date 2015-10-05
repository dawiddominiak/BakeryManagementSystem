using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PriceLists
{
    public abstract class AbstractPriceListEntity
    {
        public Dictionary<Product.ProductEntity, Shared.Structs.Money> PriceList;
        public PriceTypes PriceType { get; protected set; }

        public static Shared.Structs.Money operator *(PriceLists.AbstractPriceListEntity priceList, ProductMaps.ProductMapEntity map)
        {
            var money = new Shared.Structs.Money
            {
                Amount = 0,
                Currency = Shared.Structs.Currency.PLN //TODO: parametrisation
            };

            foreach(var productPair in map.Products)
            {
                Shared.Structs.Money productPrice;
                    
                if(!priceList.PriceList.TryGetValue(productPair.Key, out productPrice))
                {

                    throw new Shared.Exceptions.MissingProductsInPriceListException();
                }

                money += productPair.Value * productPrice;
            }

            return money;
        }

        public static Shared.Structs.Money operator *(ProductMaps.ProductMapEntity map, PriceLists.AbstractPriceListEntity priceList)
        {
            return priceList * map;
        }
    }
}
