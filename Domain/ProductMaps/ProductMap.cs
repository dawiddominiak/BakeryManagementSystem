using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Domain.ProductMaps
{
    public struct ProductMap : IEquatable<ProductMap>
    {
        public ImmutableDictionary<Product.Product, int> Products { get; private set; }

        public ProductMap(Dictionary<Product.Product, int> productMap) : this()
        {
            Products = productMap.ToImmutableDictionary();
        }

        public static ProductMap operator +(ProductMap sourceMap, ProductMap collectionMap)
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

            return new ProductMap(productsDictionary);
        }

        public static ProductMap operator -(ProductMap sourceMap, ProductMap collectionMap)
        {
            var productsDictionary = sourceMap.Products.ToDictionary(entry => entry.Key, entry => entry.Value);

            foreach (var collectionPair in collectionMap.Products)
            {
                if (!productsDictionary.ContainsKey(collectionPair.Key) && collectionPair.Value != 0)
                {

                    throw new Shared.Exceptions.NumberOfProductsLowerThanZeroException();
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

                        throw new Shared.Exceptions.NumberOfProductsLowerThanZeroException();
                    }
                }
            }

            return new ProductMap(productsDictionary);
        }

        public bool Equals(ProductMap other)
        {
            var x = Products;
            var y = other.Products;

            if (x.Count != y.Count)
            {
                return false;
            }

            if (x.Keys.Except(y.Keys).Any())
            {
                return false;
            }

            if (y.Keys.Except(x.Keys).Any())
            {
                return false;
            }

            foreach (var pair in x)
            {
                if (pair.Value != y[pair.Key])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
