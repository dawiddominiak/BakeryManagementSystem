using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Payment;
using Domain.Product;
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
        private global::Domain.ProductMaps.ProductMap _order;
        private global::Domain.ProductMaps.ProductMap _delivery;
        private global::Domain.ProductMaps.ProductMap _returns;
        private global::Domain.Payment.Payment _payment;
        private Address _address;
        private Phone _phone;

        private global::Domain.PriceLists.PriceList _priceList1;
        private global::Domain.PriceLists.PriceList _priceList2;
        private global::Domain.PriceLists.PriceList _priceList3;

        [TestInitialize]
        public void Initialization()
        {
            _name = "Example Shop Name";
            _owner = new Owner(new OwnerCode("OC"));
            _order = new global::Domain.ProductMaps.ProductMap();
            _delivery = new global::Domain.ProductMaps.ProductMap();
            _returns = new global::Domain.ProductMaps.ProductMap();
            _payment = new global::Domain.Payment.Payment(
                new PaymentId(Guid.NewGuid())
            );
            _address = new Address("Example street", "00-000", "Warsaw", "PL");
            _phone = new Phone("48", "22", "1234567");

            _shop = new global::Domain.Shop.Shop(new ShopCode("SC"))
            {
                Name = _name,
                Owner = _owner,
                Order = _order,
                Delivery = _delivery,
                Returns = _returns,
                Address = _address
            };

            _shop.Payments.Add(new DateTime(2000, 1, 1), _payment);
            _shop.Phones.Add(_phone);

            var product1 = new global::Domain.Product.Product("P1", "product 1", new TaxRate(0.23m));
            var money1 = Money.FromNative(0.25m, "Pln");
            var product2 = new global::Domain.Product.Product("P2", "product 2", new TaxRate(0.23m));
            var money2 = Money.FromNative(1m, "Pln");

            _priceList1 = new global::Domain.PriceLists.PriceList(new Dictionary<global::Domain.Product.Product, Money>()
                {
                    {product1, money1},
                    {product2, money2}
                }
            );
            _priceList2 =
                new global::Domain.PriceLists.PriceList(new Dictionary<global::Domain.Product.Product, Money>()
                {
                    {product1, money1}
                });
            _priceList3 =
                new global::Domain.PriceLists.PriceList(new Dictionary<global::Domain.Product.Product, Money>()
                {
                    {product2, money2}
                });

            _shop.PriceLists.Add(new DateTime(2010, 1, 1), _priceList1);
            _shop.PriceLists.Add(new DateTime(2013, 1, 1), _priceList2);
            _shop.PriceLists.Add(new DateTime(2015, 1, 1), _priceList3);
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
        public void HasOrder()
        {
            Assert.IsTrue(
                _order.Equals(_shop.Order)
            );
        }

        [TestMethod]
        public void HasDelivery()
        {
            Assert.IsTrue(
                _delivery.Equals(_shop.Delivery)
            );
        }

        [TestMethod]
        public void HasReturns()
        {
            Assert.IsTrue(
                _returns.Equals(_shop.Returns)
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

        [TestMethod]
        public void GetPriceList_ShouldGetFirstElement()
        {
            var priceList = _shop.GetPriceList(new DateTime(2011, 1, 1));

            Assert.IsTrue(
                priceList.Equals(_priceList1)
            );
        }

        [TestMethod]
        public void GetPriceList_ShouldGetSecondElement()
        {
            var priceList = _shop.GetPriceList(new DateTime(2014, 1, 1));

            Assert.IsTrue(
                priceList.Equals(_priceList2)
            );
        }

        [TestMethod]
        public void GetPriceList_ShouldGetLastElement()
        {
            var priceList = _shop.GetPriceList(new DateTime(2016, 1, 1));

            Assert.IsTrue(
                priceList.Equals(_priceList3)
            );
        }

        [TestMethod]
        public void GetPriceList_ShouldBeNull()
        {
            var priceList = _shop.GetPriceList(new DateTime(2000, 1, 1));

            Assert.IsNull(priceList);
        }
    }
}
