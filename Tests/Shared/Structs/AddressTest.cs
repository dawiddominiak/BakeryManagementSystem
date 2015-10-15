using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Structs;

namespace Tests.Shared.Structs
{
    [TestClass]
    public class AddressTest
    {
        private Address _address;
        private string _street;
        private string _postalCode;
        private string _city;
        private string _country;

        [TestInitialize]
        public void Initialize()
        {
            _street = "Example Street 34/15";
            _postalCode = "00-000";
            _city = "Example City";
            _country = "Poland";

            _address = new Address(
                _street, 
                _postalCode, 
                _city, 
                _country
            );
        }

        [TestMethod]
        public void TestHasStreet()
        {
            Assert.AreEqual(_address.Street, _street);
        }

        [TestMethod]
        public void TestHasPostalCode()
        {
            Assert.AreEqual(_address.PostalCode, _postalCode);
        }

        [TestMethod]
        public void TestHasCity()
        {
            Assert.AreEqual(_address.City, _city);
        }

        [TestMethod]
        public void TestHasCountry()
        {
            Assert.AreEqual(_address.Country, _country);
        }

        [TestMethod]
        public void TestSameValueAs_ShouldBeTrue()
        {
            var address = new Address(_street, _postalCode, _city, _country);
            Assert.IsTrue(
                address.SameValueAs(_address)
            );
        }

        [TestMethod]
        public void TestSameValueAs_ShouldBeFalse()
        {
            var address = new Address("Other street 200/1", _postalCode, _city, _country);
            Assert.IsFalse(
                address.SameValueAs(_address)
            );
        }

        [TestMethod]
        public void TestFromNative()
        {
            Address.FromNative(_street, _postalCode, _city, _country)
                .SameValueAs(
                    _address
                );
        }
    }
}
