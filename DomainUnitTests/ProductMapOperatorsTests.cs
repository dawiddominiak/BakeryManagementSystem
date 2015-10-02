﻿using System;
using Domain.ProductMaps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainUnitTests
{
    [TestClass]
    public class ProductMapOperatorsTests
    {
        [TestMethod]
        public void AdditionTest_OfTwoCorrectMaps_IsAddingMaps()
        {
            var product1 = new Domain.Product.ProductEntity { };
            var product2 = new Domain.Product.ProductEntity { };
            var product3 = new Domain.Product.ProductEntity { };

            var map1 = new ProductMapEntity
            {
                Products = new System.Collections.Generic.Dictionary<Domain.Product.ProductEntity, int>
                {
                    {
                        product1, 30
                    },
                    {
                        product2, 50
                    }
                }
            };

            var map2 = new ProductMapEntity
            {
                Products = new System.Collections.Generic.Dictionary<Domain.Product.ProductEntity, int>
                {
                    {
                        product2, 10
                    },
                    {
                        product3, 20
                    }
                }
            };

            var map3 = map1 + map2;

            int count;

            map3.Products.TryGetValue(product1, out count);
            Assert.AreEqual(count, 30);

            map3.Products.TryGetValue(product2, out count);
            Assert.AreEqual(count, 60);

            map3.Products.TryGetValue(product3, out count);
            Assert.AreEqual(count, 20);
        }
    }
}