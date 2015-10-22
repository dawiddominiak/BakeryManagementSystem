using System;

namespace Domain.Assortment
{
    public struct Product : IEquatable<Product>
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public TaxRate TaxRate { get; private set; }

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
    }
}
