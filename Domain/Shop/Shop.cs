using System;
using System.Collections.Generic;
using Shared;
using Shared.Structs;

namespace Domain.Shop
{
    public class Shop : IEntity<Shop>, ISeller, IAggregateRoot
    {
        public ShopCode Code { get; set; }
        public string Name { get; set; }
        public Owner Owner { get; set; }
        public SortedList<DateTime, Payment.Payment> Payments { get; set; }
        public Address Address { get; set; }
        public List<Phone> Phones { get; set; }
        public SortedList<DateTimePeriod, PriceLists.PriceList<Shop>> PriceLists { get; set; }

        public Shop(ShopCode code)
        {
            Code = code;
            Payments = new SortedList<DateTime, Payment.Payment>();
            Phones = new List<Phone>();
        }

        public bool SameIdentityAs(Shop other)
        {
            return Code.Equals(other.Code);
        }
    }
}
