namespace Shared.Structs
{
    public class Phone : IValueObject<Phone>
    {
        public string CountryCode { get; set; }
        public string RegionalCode { get; set; }
        public string Number { get; set; }

        public static Phone FromNative(string countryCode, string regionalCode, string number)
        {
            return new Phone
            {
                CountryCode = countryCode,
                RegionalCode = regionalCode,
                Number = number
            };
        }

        public bool SameValueAs(Phone other)
        {
            return CountryCode == other.CountryCode && RegionalCode == other.RegionalCode && Number == other.Number;
        }
    }
}
