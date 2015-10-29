using System;
using System.Collections.Generic;
using Domain.Assortment;
using Domain.ProductMaps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Exceptions;

namespace Tests.Domain.ProductMap
{
    public class RealProductMap : global::Domain.ProductMaps.ProductMap
    {
        public RealProductMap(ProductMapId id) : base(id)
        {
        }
    }

    [TestClass]
    public class ProductMapTest
    {
        private global::Domain.Assortment.Product _product1;
        private global::Domain.Assortment.Product _product2;
        private global::Domain.ProductMaps.ProductMap _productMap;

        [TestInitialize]
        public void Initialization()
        {

            _product1 = new global::Domain.Assortment.Product(new ProductId(Guid.NewGuid()), "P1", "Product 1", new TaxRate(0.23m));
            _product2 = new global::Domain.Assortment.Product(new ProductId(Guid.NewGuid()), "P2", "Product 2", new TaxRate(0.23m));
            _productMap = new RealProductMap(new ProductMapId(Guid.NewGuid()))
            {
                Products = new Dictionary<global::Domain.Assortment.Product, int>()
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
                new RealProductMap(new ProductMapId(Guid.NewGuid()));            

            Assert.IsFalse(
                _productMap.SameIdentityAs(productMapToCompare)
            );
        }

        [TestMethod]
        public void SameIdentityAs_OfMapsWithTheSameId_ShouldBeTrue()
        {
            var productMapToCompare = new RealProductMap(_productMap.Id);            

            Assert.IsTrue(
                _productMap.SameIdentityAs(productMapToCompare)
            );
        }

        [TestMethod]
        public void TestAddOperator()
        {
            var products1 = new RealProductMap(new ProductMapId(Guid.NewGuid()))
            {
                Products = new Dictionary<global::Domain.Assortment.Product, int>()
                {
                    {_product1, 5}
                }
            };

            var products2 =
                new RealProductMap(new ProductMapId(Guid.NewGuid()))
            {
                Products = new Dictionary<global::Domain.Assortment.Product, int>()
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
            var productsToSubtract = new RealProductMap(new ProductMapId(Guid.NewGuid()))
            {
                Products = new Dictionary<global::Domain.Assortment.Product, int>()
                {
                    {_product1, 20}
                }
            };

            try
            {
                // ReSharper disable once UnusedVariable
                // Needed for test.
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
            var productsToSubtract = new RealProductMap(new ProductMapId(Guid.NewGuid()))
            {
                Products = new Dictionary<global::Domain.Assortment.Product, int>()
                {
                    {_product1, 10},
                    {_product2, 2}
                }
            };

            var result = _productMap - productsToSubtract;

            Assert.AreEqual(result[_product2], 3);
            Assert.IsFalse(result.ContainsKey(_product1));
        }
    }
}
