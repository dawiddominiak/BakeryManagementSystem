using Shared;

namespace Domain.Shop
{
    public class OwnerCode : IValueObject<OwnerCode>
    {
        public string Code { get; private set; }

        public OwnerCode(string code)
        {
            Code = code;
        }

        public bool SameValueAs(OwnerCode other)
        {
            return Code == other.Code;
        }
    }
}
