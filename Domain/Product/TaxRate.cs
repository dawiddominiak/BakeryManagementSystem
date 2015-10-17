using System;

namespace Domain.Product
{
    public struct TaxRate : IEquatable<TaxRate>
    {
        public decimal Rate { get; private set; }

        public TaxRate(decimal rate) : this()
        {
            Rate = rate;
        }

        public bool Equals(TaxRate other)
        {
            return Rate == other.Rate;
        }
    }
}
