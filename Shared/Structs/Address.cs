using System;
using System.Xml;

namespace Shared.Structs
{
    public class Address : IValueObject<Address>
    {
        public string Street { get; private set; }
        public string PostalCode { get; private set; }
        public string Country { get; private set; }
        public string City { get; private set; }

        public Address(string street, string postalCode, string city, string country)
        {
            Street = street;
            PostalCode = postalCode;
            City = city;
            Country = country;
        }

        public static Address FromNative(string street, string postalCode, string country)
        {
            return new Address(street, postalCode, country);
        }

        public bool SameValueAs(Address other)
        {
            return Street == other.Street && PostalCode == other.PostalCode && Country == other.Country;
        }

        public override string ToString()
        {
            return Environment.NewLine
        }
    }
}
