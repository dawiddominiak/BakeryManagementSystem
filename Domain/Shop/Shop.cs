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
        public List<Payment.Payment> Payments { get; private set; }
        public Address Address { get; set; }
        public List<Phone> Phones { get; private set; }
        public SortedList<DateTime, PriceList> PriceLists { get; private set; } 

        public Shop(ShopCode code)
        {
            Code = code;
            Payments = new List<Payment.Payment>();
            Phones = new List<Phone>();
            PriceLists = new SortedList<DateTime, PriceList>();
        }

        public PriceList? GetPriceList(DateTime dateTime)
        {
            var previousDate = new DateTime(1000, 1, 1);

            foreach (var pair in PriceLists.Where(pair => previousDate.CompareTo(dateTime) <= 0 && pair.Key.CompareTo(dateTime) > 0))
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
