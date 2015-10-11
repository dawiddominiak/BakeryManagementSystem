using Shared;

namespace Domain.Product
{
    public class TaxRate : IValueObject<TaxRate>
    {
        public decimal Rate { get; set; }

        public bool SameValueAs(TaxRate other)
        {
            return Rate == other.Rate;
        }
    }
}
