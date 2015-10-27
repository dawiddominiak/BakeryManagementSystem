using System;
using System.Globalization;

namespace Domain.Assortment
{
    public struct TaxRate : IEquatable<TaxRate>
    {
        public decimal Rate { get; set; }

        public TaxRate(decimal rate) : this()
        {
            Rate = rate;
        }

        public bool Equals(TaxRate other)
        {
            return Rate.Equals(other.Rate);
        }

        public override string ToString()
        {
            return Rate.ToString(CultureInfo.InvariantCulture);
        }
    }
}
