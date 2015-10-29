using System;
using System.Linq;
using Domain.Payment;
using Domain.Shop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Structs;

namespace Tests.Domain.Shop
{
    [TestClass]
    public class ShopTest
    {
        private global::Domain.Shop.Shop _shop;
        private string _name;
        private Owner _owner;
        private global::Domain.Payment.Payment _payment;
        private Address _address;
        private Phone _phone;

        [TestInitialize]
        public void Initialization()
        {
            _name = "Example Shop Name";
            _owner = new Owner(new OwnerId(Guid.NewGuid()));
            _payment = new global::Domain.Payment.Payment(
                new PaymentId(Guid.NewGuid())
            );
            _address = new Address("Example street", "00-000", "Warsaw", "PL");
            _phone = new Phone("48", "22", "1234567");

            _shop = new global::Domain.Shop.Shop(new ShopCode("SC"))
            {
                Name = _name,
                Owner = _owner,
                Address = _address
            };

            _shop.Payments.Add(new DateTime(2000, 1, 1), _payment);
            _shop.Phones.Add(_phone);

        }

        [TestMethod]
        public void HasCode()
        {
            Assert.IsTrue(
                _shop.Code.Equals(
                    new ShopCode("SC")
                )
            );
        }

        [TestMethod]
        public void HasName()
        {
            Assert.AreEqual(
                _shop.Name, _name
            );
        }

        [TestMethod]
        public void HasOwner()
        {
            Assert.IsTrue(
                _owner.SameIdentityAs(_shop.Owner)    
            );
        }

        [TestMethod]
        public void HasPayments()
        {
            Assert.IsTrue(
                _shop.Payments.First().Value.SameIdentityAs(_payment)    
            );
        }

        [TestMethod]
        public void HasAddress()
        {
            Assert.IsTrue(
                _shop.Address.Equals(_address)    
            );
        }

        [TestMethod]
        public void HasPhone()
        {
            Assert.IsTrue(
                _shop.Phones.First().Equals(_phone)    
            );
        }

        [TestMethod]
        public void SameIdentityAs_ShouldBeFalse()
        {
            Assert.IsFalse(
                _shop.SameIdentityAs(new global::Domain.Shop.Shop(new ShopCode("OCS")))
            );
        }

        [TestMethod]
        public void SameIdentityAs_ShoudBeTrue()
        {
            Assert.IsTrue(
                _shop.SameIdentityAs(new global::Domain.Shop.Shop(new ShopCode("SC")))
            );
        }
    }
}
