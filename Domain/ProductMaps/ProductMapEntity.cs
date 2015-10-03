using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProductMaps
{
    public class ProductMapEntity
    {
        public Dictionary<Product.ProductEntity, int> Products { get; set; }

        public static ProductMapEntity operator +(ProductMapEntity sourceMap, ProductMapEntity collectionMap)
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

            return new ProductMapEntity
            {
                Products = productsDictionary
            };
        }

        public static ProductMapEntity operator -(ProductMapEntity sourceMap, ProductMapEntity collectionMap)
        {
            var productsDictionary = sourceMap.Products.ToDictionary(entry => entry.Key, entry => entry.Value);

            foreach (var collectionPair in collectionMap.Products)
            {
                if (!productsDictionary.ContainsKey(collectionPair.Key) && collectionPair.Value != 0)
                {

                    throw new Application.Exceptions.NumberOfProductsLowerThanZeroException();
                } 
                else if(productsDictionary.ContainsKey(collectionPair.Key))
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

                        throw new Application.Exceptions.NumberOfProductsLowerThanZeroException();
                    }
                }
            }

            return new ProductMapEntity
            {
                Products = productsDictionary
            };
        }
    }
}
