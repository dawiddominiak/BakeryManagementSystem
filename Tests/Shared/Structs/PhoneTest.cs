using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Structs;

namespace Tests.Shared.Structs
{
    [TestClass]
    public class PhoneTest
    {
        private Phone _phone;
        private string _country;
        private string _area;
        private string _number;

        [TestInitialize]
        public void Initialize()
        {
            _country = "48";
            _area = "22";
            _number = "1234567";

            _phone = new Phone(
                _country,
                _area,
                _number
            );
        }

        [TestMethod]
        public void TestHasCountry()
        {
            Assert.AreEqual(_phone.CountryCode, _country);
        }

        [TestMethod]
        public void TestHasArea()
        {
            Assert.AreEqual(_phone.RegionalCode, _area);
        }

        [TestMethod]
        public void TestHasNumber()
        {
            Assert.AreEqual(_phone.Number, _number);
        }

        [TestMethod]
        public void TestSameValueAs_ShouldBeTrue()
        {
            var phoneToCompare = new Phone(_country, _area, _number);
            
            Assert.IsTrue(
                _phone.SameValueAs(
                    phoneToCompare
                )
            );
        }

        [TestMethod]
        public void TestSameValueAs_ShouldBeFalse()
        {
            var phoneToCompare = new Phone(_country, _area, "7654321");

            Assert.IsFalse(
                _phone.SameValueAs(
                    phoneToCompare
                )
            );
        }

        [TestMethod]
        public void TestFromNative()
        {
            Assert.IsTrue(condition: Phone.FromNative(_country, _area, _number)
                    .SameValueAs(
                        _phone
                    )
            );
        }
    }
}
