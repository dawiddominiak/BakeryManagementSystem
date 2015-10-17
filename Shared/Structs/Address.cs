using System;

namespace Shared.Structs
{
    public struct Address : IEquatable<Address>
    {
        public string Street { get; private set; }
        public string PostalCode { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }

        public Address(string street, string postalCode, string city, string country) : this()
        {
            Street = street;
            PostalCode = postalCode;
            City = city;
            Country = country;
        }

        public static Address FromNative(string street, string postalCode, string city, string country)
        {
            return new Address(street, postalCode, city, country);
        }

        public override string ToString()
        {
            string[] arr = {
                Street,
                PostalCode,
                City,
                Country
            };

            return string.Join(Environment.NewLine, arr);
        }

        bool IEquatable<Address>.Equals(Address other)
        {
            return Street == other.Street
               && PostalCode == other.PostalCode
               && City == other.City
               && Country == other.Country;
        }
    }
}