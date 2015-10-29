using System;
using Shared;

namespace Domain.Assortment
{
    public class Product : IEntity<Product>, IComparable<Product>
    {
        public ProductId Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public TaxRate TaxRate { get; set; }

        public Product()
        { }

        public Product(ProductId id, string code, string name, TaxRate taxRate)
        {
            Id = id;
            Code = code;
            Name = name;
            TaxRate = taxRate;
        }

        public int CompareTo(Product other)
        {
            return string.Compare(ToString(), other.ToString(), StringComparison.Ordinal);
        }

        public bool SameIdentityAs(Product other)
        {
            return Id.Equals(other.Id);
        }

        public override string ToString()
        {
            return Code + " " + Name + " " + TaxRate;
        }
    }
}
