using System;

namespace Domain.Assortment
{
    public struct Product : IEquatable<Product>, IComparable<Product>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public TaxRate TaxRate { get; set; }

        public Product(string code, string name, TaxRate taxRate) : this()
        {
            Code = code;
            Name = name;
            TaxRate = taxRate;
        }

        public bool Equals(Product other)
        {
            return Code == other.Code &&
                Name == other.Name &&
                TaxRate.Equals(other.TaxRate);
        }

        public int CompareTo(Product other)
        {
            return string.Compare(ToString(), other.ToString(), StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return Code + " " + Name + " " + TaxRate;
        }
    }
}
