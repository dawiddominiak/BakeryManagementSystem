using Shared;

namespace Domain.Product
{
    public class ProductCode : IValueObject<ProductCode>
    {
        public string Code { get; private set; }

        public ProductCode(string code)
        {
            Code = code;
        }

        public bool SameValueAs(ProductCode other)
        {
            return Code == other.Code;
        }
    }
}
