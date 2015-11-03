using System;

namespace Shared.Structs
{
    public struct Phone : IEquatable<Phone>
    {
        public string CountryCode { get; set; }
        public string RegionalCode { get; set; }
        public string Number { get; set; }

        public Phone(string countryCode, string regionalCode, string number) : this()
        {
            CountryCode = countryCode;
            RegionalCode = regionalCode;
            Number = number;
        }

        public static Phone FromNative(string countryCode, string regionalCode, string number)
        {
            return new Phone(countryCode, regionalCode, number);
        }

        public override string ToString()
        {
            return CountryCode + " " + RegionalCode + " " + Number;
        }

        public bool Equals(Phone other)
        {
            return CountryCode == other.CountryCode
                && RegionalCode == other.RegionalCode
                && Number == other.Number;
        }
    }
}
