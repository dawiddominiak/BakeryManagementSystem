//using System;
//using System.Collections.Generic;
//using Domain.Assortment;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//
//namespace Tests.Domain.Product
//{
//    /// <summary>
//    /// Unit tests of Assortment.
//    /// </summary>
//    [TestClass]
//    public class AssortmentTest
//    {
//        private Assortment _assortment;
//
//        [TestInitialize]
//        public void OnTestInitialize()
//        {
//            _assortment = new Assortment();
//        }
//
//        [TestMethod]
//        public void HasAccessToProducts()
//        {
//            Assert.IsInstanceOfType(
//                _assortment.Products,
//                typeof(List<global::Domain.Assortment.Product>)
//            );
//        }
//
//        [TestMethod]
//        public void Equals_ShouldBeFalse()
//        {
//            var assortment1 = new Assortment(
//                new List<global::Domain.Assortment.Product>
//                {
//                    new global::Domain.Assortment.Product(new ProductId(Guid.NewGuid()), "P1", "Big bread", new TaxRate(0.23m)),
//                    new global::Domain.Assortment.Product(new ProductId(Guid.NewGuid()), "P2", "Small bread", new TaxRate(0.23m))
//                }
//            );
//
//            var assortment2 = new Assortment(
//                new List<global::Domain.Assortment.Product>
//                {
//                    new global::Domain.Assortment.Product(new ProductId(Guid.NewGuid()), "P1", "Big bread", new TaxRate(0.23m)),
//                    new global::Domain.Assortment.Product(new ProductId(Guid.NewGuid()), "P3", "Other bread", new TaxRate(0.23m)),
//                    new global::Domain.Assortment.Product(new ProductId(Guid.NewGuid()), "P2", "Small bread", new TaxRate(0.23m))            
//                }
//            );
//
//            Assert.IsFalse(
//                assortment1.Equals(assortment2)
//            );
//        }
//
//        [TestMethod]
//        public void Equals_ShouldBeTrue()
//        {
//            var assortment1 = new Assortment(
//                new List<global::Domain.Assortment.Product>
//                {
//                    new global::Domain.Assortment.Product(new ProductId(Guid.NewGuid()), "P1", "Big bread", new TaxRate(0.23m)),
//                    new global::Domain.Assortment.Product(new ProductId(Guid.NewGuid()), "P2", "Small bread", new TaxRate(0.23m))
//                }
//            );
//
//            var assortment2 = new Assortment(
//                new List<global::Domain.Assortment.Product>
//                {
//                    new global::Domain.Assortment.Product(new ProductId(Guid.NewGuid()), "P2", "Small bread", new TaxRate(0.23m)),
//                    new global::Domain.Assortment.Product(new ProductId(Guid.NewGuid()), "P1", "Big bread", new TaxRate(0.23m))
//                }
//            );
//
//            Assert.IsTrue(
//                assortment1.Equals(assortment2)
//            );
//        }
//    }
//}
