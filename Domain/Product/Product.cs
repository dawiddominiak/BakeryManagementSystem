using Shared;

namespace Domain.Product
{
    public class Product : IEntity<Product>
    {
        public ProductCode Code { get; private set; }
        public string Name { get; set; }
        public TaxRate TaxRate { get; set; }

        public Product(ProductCode code)
        {
            Code = code;
        }

        public bool SameIdentityAs(Product other)
        {
            return Code.SameValueAs(other.Code);
        }
    }
}
