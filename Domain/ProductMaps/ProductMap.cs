using System.Collections.Generic;
using System.Linq;
using Shared;
using Shared.Exceptions;

namespace Domain.ProductMaps
{
    public abstract class ProductMap : IEntity<ProductMap>
    {
        public ProductMapId Id { get; private set; }
        public Dictionary<Assortment.Product, int> Products { get; set; }

        protected ProductMap(ProductMapId id)
        {
            Id = id;
            Products = new Dictionary<Assortment.Product, int>();
        }

        public static Dictionary<Assortment.Product, int> operator +(ProductMap sourceMap, ProductMap collectionMap)
        {
            
            var productsDictionary = sourceMap.Products.ToDictionary(entry => entry.Key, entry => entry.Value);

            foreach (var collectionPair in collectionMap.Products)
            {
                if (!productsDictionary.ContainsKey(collectionPair.Key))
                {
                    productsDictionary.Add(collectionPair.Key, collectionPair.Value);
                }
                else
                {
                    productsDictionary[collectionPair.Key] += collectionPair.Value;
                }
            }

            return productsDictionary;
        }

        public static Dictionary<Assortment.Product, int> operator -(ProductMap sourceMap, ProductMap collectionMap)
        {
            var productsDictionary = sourceMap.Products.ToDictionary(entry => entry.Key, entry => entry.Value);

            foreach (var collectionPair in collectionMap.Products)
            {
                if (!productsDictionary.ContainsKey(collectionPair.Key) && collectionPair.Value != 0)
                {

                   throw new NumberOfProductsLowerThanZeroException();
                } 
                
                if(productsDictionary.ContainsKey(collectionPair.Key))
                {
                    if(collectionPair.Value < productsDictionary[collectionPair.Key])
                    {
                        productsDictionary[collectionPair.Key] -= collectionPair.Value;
                    }
                    else if(collectionPair.Value == productsDictionary[collectionPair.Key])
                    {
                        productsDictionary.Remove(collectionPair.Key);
                    }
                    else
                    {

                        throw new NumberOfProductsLowerThanZeroException();
                    }
                }
            }

            return productsDictionary;
        }

        public bool SameIdentityAs(ProductMap other)
        {
            return Id.Equals(other.Id);
        }
    }
}
