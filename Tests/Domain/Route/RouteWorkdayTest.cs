using System;
using System.Collections.Generic;
using Domain.Product;
using Domain.Route;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Route
{
    /// <summary>
    /// Unit tests of RouteWorkday.
    /// </summary>
    [TestClass]
    public class RouteWorkdayTest
    {
        private global::Domain.Product.Product _product1;
        private global::Domain.Product.Product _product2;
        private global::Domain.ProductMaps.ProductMap _warehouseIssue;
        private global::Domain.ProductMaps.ProductMap _issuedGoods;
        private global::Domain.ProductMaps.ProductMap _returnedGoods;
        private global::Domain.ProductMaps.ProductMap _returnedReturns;
        
        private DateTime _dateTime;
        private RouteWorkday _routeWorkday;

        [TestInitialize]
        public void OnTestInitialize()
        {
            _product1 = new global::Domain.Product.Product("P1", "product 1", new TaxRate(0.23m));
            _product2 = new global::Domain.Product.Product("P2", "product 2", new TaxRate(0.23m));

            _dateTime = new DateTime(2000, 1, 1);

            _warehouseIssue = new global::Domain.ProductMaps.ProductMap(new Dictionary<global::Domain.Product.Product, int>()
            {
                {_product1, 1},
                {_product2, 2}
            });

            _issuedGoods = new global::Domain.ProductMaps.ProductMap(new Dictionary<global::Domain.Product.Product, int>()
            {
                {_product1, 3},
                {_product2, 4}
            });

            _returnedGoods = new global::Domain.ProductMaps.ProductMap(new Dictionary<global::Domain.Product.Product, int>()
            {
                {_product1, 5},
                {_product2, 6}
            });

            _returnedReturns = new global::Domain.ProductMaps.ProductMap(new Dictionary<global::Domain.Product.Product, int>()
            {
                {_product1, 7},
                {_product2, 8}
            });

            _routeWorkday = new RouteWorkday(_dateTime, _warehouseIssue, _issuedGoods, _returnedGoods, _returnedReturns);
        }

        [TestMethod]
        public void HasDate()
        {
            Assert.AreEqual(_routeWorkday.Date, _dateTime);
        }

        [TestMethod]
        public void HasWarehouseIssue()
        {
            Assert.IsTrue(
                _routeWorkday.WarehouseIssue.Equals(_warehouseIssue)    
            );
        }

        [TestMethod]
        public void HasIssuedGoods()
        {
            Assert.IsTrue(
                _routeWorkday.IssuedGoods.Equals(_issuedGoods)    
            );
        }

        [TestMethod]
        public void HasReturnedGoods()
        {
            Assert.IsTrue(
                _routeWorkday.ReturnedGoods.Equals(_returnedGoods)
            );
        }

        [TestMethod]
        public void HasReturnedReturns()
        {
            Assert.IsTrue(
                _routeWorkday.ReturnedReturns.Equals(_returnedReturns)
            );
        }

        [TestMethod]
        public void Equals_ShouldBeFalse()
        {
            Assert.IsFalse(
                _routeWorkday.Equals(new RouteWorkday(_dateTime, _returnedReturns, _returnedGoods, _issuedGoods, _warehouseIssue))    
            );
        }

        [TestMethod]
        public void Equals_ShouldBeTrue()
        {
            Assert.IsTrue(
                _routeWorkday.Equals(new RouteWorkday(_dateTime, _warehouseIssue, _issuedGoods, _returnedGoods, _returnedReturns))    
            );
        }
    }
}
