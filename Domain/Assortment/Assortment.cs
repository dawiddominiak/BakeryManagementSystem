using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Domain.Assortment
{
    public class Assortment : IEquatable<Assortment>
    {
        public List<Product> Products { get; set; }

        public Assortment()
        {
            Products = new List<Product>();
        }

        public Assortment(List<Product> products)
        {
            Products = products;
        }

        public bool Equals(Assortment other)
        {
            var sortedProducts = Products.ToImmutableSortedSet();
            var otherSortedProducts = other.Products.ToImmutableSortedSet();
            
            return sortedProducts.Count == otherSortedProducts.Count &&
                sortedProducts.SequenceEqual(otherSortedProducts);
        }
    }
}
