using System;
using System.Collections.Generic;
using Domain.PriceLists;
using Shared;
using Shared.Structs;

namespace Domain.Shop
{
    public class Shop : IEntity<Shop>
    {
        public ShopId Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Owner Owner { get; set; }
        public SortedList<DateTime, Payment.Payment> Payments { get; set; } 
            = new SortedList<DateTime, Payment.Payment>();
        public Address Address { get; set; }
        public List<Phone> Phones { get; set; } = new List<Phone>();
        public SortedList<DateTimePeriod, PriceList<Shop>> PriceLists { get; set; } 
            = new SortedList<DateTimePeriod, PriceList<Shop>>();

        public Shop()
        { }

        public Shop(ShopId id)
        {
            Id = id;
        }

        public bool SameIdentityAs(Shop other)
        {
            return Id.Equals(other.Id);
        }
    }
}
