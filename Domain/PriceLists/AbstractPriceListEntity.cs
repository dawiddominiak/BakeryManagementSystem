using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PriceLists
{
    public abstract class AbstractPriceListEntity
    {
        public Dictionary<Product.ProductEntity, Application.Shared.Money> PriceList;
        public PriceTypes PriceType { get; protected set; }

        public static Application.Shared.Money operator *(PriceLists.AbstractPriceListEntity priceList, ProductMaps.ProductMapEntity map)
        {
            var money = new Application.Shared.Money
            {
                Amount = 0,
                Currency = Application.Shared.Currency.PLN //TODO: parametrisation
            };

            foreach(var productPair in map.Products)
            {
                Application.Shared.Money productPrice;
                    
                if(!priceList.PriceList.TryGetValue(productPair.Key, out productPrice))
                {

                    throw new Application.Exceptions.MissingProductsInPriceListException();
                }

                money += productPair.Value * productPrice;
            }

            return money;
        }

        public static Application.Shared.Money operator *(ProductMaps.ProductMapEntity map, PriceLists.AbstractPriceListEntity priceList)
        {
            return priceList * map;
        }
    }
}
