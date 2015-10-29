using System;
using System.Collections.Generic;
using Domain.Assortment;
using Domain.PriceLists;
using Domain.ProductMaps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Exceptions;
using Shared.Structs;

namespace Tests.Domain.PriceList
{
    public class RealProductMap : global::Domain.ProductMaps.ProductMap
    {
        public RealProductMap(ProductMapId id) : base(id)
        {
        }
    }

    [TestClass]
    public class PriceListTest
    {
        private global::Domain.PriceLists.PriceList<global::Domain.Route.Route> _priceList;
        private global::Domain.ProductMaps.ProductMap _productMap;
        private global::Domain.Assortment.Product _product1;
        private global::Domain.Assortment.Product _product2;

        [TestInitialize]
        public void Initialization()
        {
            _product1 = new global::Domain.Assortment.Product(new ProductId(Guid.NewGuid()), "P1", "Product 1", new TaxRate(0.23m));
            _product2 = new global::Domain.Assortment.Product(new ProductId(Guid.NewGuid()), "P2", "Product 2", new TaxRate(0.08m));
            _productMap = new RealProductMap(new ProductMapId(Guid.NewGuid()))
            {
                Products = new Dictionary<global::Domain.Assortment.Product, int>()
                {
                    {_product1, 20},
                    {_product2, 250}
                }
            };

            _priceList = new global::Domain.PriceLists.PriceList<global::Domain.Route.Route>(new PriceListId(Guid.NewGuid()))
            {
                Prices = new Dictionary<global::Domain.Assortment.Product, Money>()
                {
                    {_product1, Money.FromNative(2.35m, "Pln")},
                    {_product2, Money.FromNative(0.45m, "Pln")}
                }
            };
        }

        [TestMethod]
        public void HasPrices()
        {
            Assert.IsTrue(_priceList.Prices[_product1].Equals(Money.FromNative(2.35m, "Pln")));
            Assert.IsTrue(_priceList.Prices[_product2].Equals(Money.FromNative(0.45m, "Pln")));
        }



        [TestMethod]
        public void Equals_OfPriceListsWithHigherLength_ShouldBeFalse()
        {
            var priceListToCompare = new global::Domain.PriceLists.PriceList<global::Domain.Route.Route>(new PriceListId(Guid.NewGuid()))
            {
                Prices = new Dictionary<global::Domain.Assortment.Product, Money>()
                {
                    {_product1, Money.FromNative(2.35m, "Pln")},
                    {_product2, Money.FromNative(0.45m, "Pln")},
                    {new global::Domain.Assortment.Product(new ProductId(Guid.NewGuid()), "P3", "Product 3", new TaxRate(0.23m)), Money.FromNative(0.10m, "Pln")}
                }
            };

            Assert.IsFalse(
                _priceList.Equals(priceListToCompare)
            );
        }

        [TestMethod]
        public void SameIdentityAs_OfPriceListsWithDifferentIds_ShouldBeFalse()
        {
            var priceListsToCompare =
                new global::Domain.PriceLists.PriceList<global::Domain.Route.Route>(new PriceListId(Guid.NewGuid()));
            
            Assert.IsFalse(
                _priceList.SameIdentityAs(priceListsToCompare)
            );
        }

        [TestMethod]
        public void SameIdentityAs_OfTwoMapsWithSameId_ShouldBeTrue()
        {
            var priceListsToCompare = new global::Domain.PriceLists.PriceList<global::Domain.Route.Route>(_priceList.Id);            

            Assert.IsTrue(
                _priceList.SameIdentityAs(priceListsToCompare)
            );
        }

        [TestMethod]
        public void MultiplyOperator_OfIncompatibilePriceList_ShouldThrowAnError()
        {
            try
            {
                var testPriceList = new global::Domain.PriceLists.PriceList<global::Domain.Route.Route>(new PriceListId(Guid.NewGuid()))
                {
                    Prices = new Dictionary<global::Domain.Assortment.Product, Money>()
                    {
                        {_product1, Money.FromNative(2.35m, "Pln")}
                    }
                };

                // ReSharper disable once UnusedVariable
                var money = testPriceList * _productMap;

                throw new Exception("Unexpected success!");
            }
            catch (MissingProductsInPriceListException e)
            {
                Assert.IsNotNull(e);
            }
        }

        [TestMethod]
        public void MultiplyOperator_OfEmptyProductMap_ShouldReturnZeroMoney()
        {
            var money = new global::Domain.PriceLists.PriceList<global::Domain.Route.Route>(new PriceListId(Guid.NewGuid())) * new RealProductMap(new ProductMapId(Guid.NewGuid()));

            Assert.IsTrue(
                money.Equals(new Money(0m))    
            );
        }

        [TestMethod]
        public void MultiplyOperator_OfProperPriceList_ShouldGivesMoney()
        {
            var money = _priceList * _productMap;
            Assert.IsTrue(
                money.Equals(Money.FromNative(159.50m, "Pln"))
            );
        }

        [TestMethod]
        public void MultiplyOperator_ShouldBeIndependendOnPlace()
        {
            Assert.IsTrue(
                (_priceList*_productMap).Equals(_productMap*_priceList)
            );
        }
    }
}
