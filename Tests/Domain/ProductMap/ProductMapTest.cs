using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Product;
using Domain.ProductMaps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Exceptions;

namespace Tests.Domain.ProductMap
{
    [TestClass]
    public class ProductMapTest
    {
        private global::Domain.Product.Product _product1;
        private global::Domain.Product.Product _product2;
        private global::Domain.ProductMaps.ProductMap _productMap;

        [TestInitialize]
        public void Initialization()
        {

            _product1 = new global::Domain.Product.Product("P1", "Product 1", new TaxRate(0.23m));
            _product2 = new global::Domain.Product.Product("P2", "Product 2", new TaxRate(0.23m));
            _productMap = new global::Domain.ProductMaps.ProductMap(new ProductMapId(Guid.NewGuid()))
            {
                Products = new Dictionary<global::Domain.Product.Product, int>()
                {
                    {
                        _product1, 10
                    },
                    {
                        _product2, 5
                    }
                }
            };
        }

        [TestMethod]
        public void HasProducts()
        {
            int count1;
            int count2;
            
            _productMap.Products.TryGetValue(_product1, out count1);
            _productMap.Products.TryGetValue(_product2, out count2);

            Assert.AreEqual(count1, 10);
            Assert.AreEqual(count2, 5);
        }

        [TestMethod]
        public void SameIdentityAs_OfProductMapsWithDifferentId_ShouldBeFalse()
        {
            var productMapToCompare =
                new global::Domain.ProductMaps.ProductMap(new ProductMapId(Guid.NewGuid()));            

            Assert.IsFalse(
                _productMap.SameIdentityAs(productMapToCompare)
            );
        }

        [TestMethod]
        public void SameIdentityAs_OfMapsWithTheSameId_ShouldBeTrue()
        {
            var productMapToCompare = new global::Domain.ProductMaps.ProductMap(_productMap.Id);            

            Assert.IsTrue(
                _productMap.SameIdentityAs(productMapToCompare)
            );
        }

        [TestMethod]
        public void TestAddOperator()
        {
            var products1 = new global::Domain.ProductMaps.ProductMap(new ProductMapId(Guid.NewGuid()))
            {
                Products = new Dictionary<global::Domain.Product.Product, int>()
                {
                    {_product1, 5}
                }
            };

            var products2 =
                new global::Domain.ProductMaps.ProductMap(new ProductMapId(Guid.NewGuid()))
            {
                Products = new Dictionary<global::Domain.Product.Product, int>()
                {
                    {_product1, 5},
                    {_product2, 5}
                }
            };

            var result = products1 + products2;

            Assert.AreEqual(result[_product1], 10);
            Assert.AreEqual(result[_product2], 5);
        }

        [TestMethod]
        public void SubtractOperator_ShouldThrowException()
        {
            var productsToSubtract = new global::Domain.ProductMaps.ProductMap(new ProductMapId(Guid.NewGuid()))
            {
                Products = new Dictionary<global::Domain.Product.Product, int>()
                {
                    {_product1, 20}
                }
            };

            try
            {
                var result = _productMap - productsToSubtract;

                throw new Exception("Unexpected success");
            }
            catch (NumberOfProductsLowerThanZeroException e)
            {
                Assert.IsNotNull(e);
            }
        }

        [TestMethod]
        public void SubtractOperator_ShouldCorrectlySubtractTwoMaps()
        {
            var productsToSubtract = new global::Domain.ProductMaps.ProductMap(new ProductMapId(Guid.NewGuid()))
            {
                Products = new Dictionary<global::Domain.Product.Product, int>()
                {
                    {_product1, 10}
                }
            };

            var result = _productMap - productsToSubtract;

            Assert.AreEqual(result[_product2], 5);
            Assert.IsFalse(result.ContainsKey(_product1));
        }
    }
}
