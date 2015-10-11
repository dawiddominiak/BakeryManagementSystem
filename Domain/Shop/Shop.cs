using System.Collections.Generic;
using Domain.ProductMaps;
using Shared;
using Shared.Structs;

namespace Domain.Shop
{
    public class Shop : IEntity<Shop>
    {
        public ShopCode Code { get; private set; }
        public string Name { get; set; }
        public Owner Owner { get; set; }
        public ProductMap Order { get; set; }
        public ProductMap Delivery { get; set; }
        public ProductMap Returns { get; set; }
        public List<Payment.Payment> Payments { get; private set; }
        public Address Address { get; set; }
        public List<Phone> Phones { get; private set; }

        public Shop(ShopCode code)
        {
            Code = code;
            Payments = new List<Payment.Payment>();
            Phones = new List<Phone>();
        }

        public bool SameIdentityAs(Shop other)
        {
            return Code.SameValueAs(other.Code);
        }
    }
}
