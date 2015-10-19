using System.Linq;
using Domain.Shop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Structs;

namespace Tests.Domain.Shop
{
    [TestClass]
    public class OwnerTest
    {
        private Owner _owner;
        private Address _address;
        private string _name;
        private string _nationalEconomyRegister;
        private string _taxIdentificationNumber;
        private Phone _phone;

        [TestInitialize]
        public void Initialization()
        {
            _address = Address.FromNative("Example Street", "00-000", "Warsaw", "PL");
            _name = "Cookie Dominiak";
            _nationalEconomyRegister = "123456789";
            _taxIdentificationNumber = "987654321";
            _phone = new Phone("48", "22", "1234567");

            _owner = new Owner(new OwnerCode("OC"))
            {
                Address = _address,
                Name = _name,
                NationalEconomyRegister = _nationalEconomyRegister,
                TaxIdentificationNumber = _taxIdentificationNumber
            };

            _owner.Phones.Add(_phone);
        }

        [TestMethod]
        public void HasAddress()
        {
            Assert.IsTrue(
                _address.Equals(_owner.Address)
            );
        }

        [TestMethod]
        public void HasName()
        {
            Assert.AreEqual(_owner.Name, _name);
        }

        [TestMethod]
        public void HasNationalEconomyRegister()
        {
            Assert.AreEqual(_owner.NationalEconomyRegister, _nationalEconomyRegister);
        }

        [TestMethod]
        public void HasTaxIdentificationNumber()
        {
            Assert.AreEqual(_taxIdentificationNumber, _owner.TaxIdentificationNumber);
        }

        [TestMethod]
        public void HasPhone()
        {
            Assert.IsTrue(
                _phone.Equals(_owner.Phones.First())
            );
        }

        [TestMethod]
        public void SameIdentityAs_ShouldBeFalse()
        {
            Assert.IsFalse(
                _owner.SameIdentityAs(
                    new Owner(new OwnerCode("OD"))
                )
            );
        }

        [TestMethod]
        public void SameIdentityAs_ShouldBeTrue()
        {
            Assert.IsTrue(
                _owner.SameIdentityAs(
                    new Owner(new OwnerCode("OC"))
                )
            );
        }
    }
}
