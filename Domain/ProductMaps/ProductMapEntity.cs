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
    }
}
