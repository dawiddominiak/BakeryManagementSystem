using System;
using System.Collections.Generic;
using System.Linq;
using Domain.PriceLists;
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
        public SortedList<DateTime, Payment.Payment> Payments { get; private set; }
        public Address Address { get; set; }
        public List<Phone> Phones { get; private set; }
        public SortedList<DateTime, PriceList> PriceLists { get; private set; } 

        public Shop(ShopCode code)
        {
            Code = code;
            Payments = new SortedList<DateTime, Payment.Payment>();
            Phones = new List<Phone>();
            PriceLists = new SortedList<DateTime, PriceList>();
        }

        public PriceList? GetPriceList(DateTime dateTime)
        {
            foreach (var pair in PriceLists.Reverse().Where(pair => dateTime.CompareTo(pair.Key) >= 0))
            {
                return pair.Value;
            }

            return null;
        }

        public bool SameIdentityAs(Shop other)
        {
            return Code.Equals(other.Code);
        }
    }
}
