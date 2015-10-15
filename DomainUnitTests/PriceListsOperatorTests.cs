//using System;
//using Domain.ProductMaps;
//using Domain.PriceLists;
//using Domain.Product;
//using Shared.Structs;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//
//namespace DomainUnitTests
//{
//    [TestClass]
//    public class PriceListsOperatorTests
//    {
//        private Product _exampleProduct1;
//        private Product _exampleProduct2;
//        private Product _exampleProduct3;
//
//        private ProductMap _exampleProductMap;
//
//        [TestInitialize]
//        public void Initialize()
//        {
//            _exampleProduct1 = new Product(new ProductCode("P1"));
//            _exampleProduct2 = new Product(new ProductCode("P2"));
//            _exampleProduct3 = new Product(new ProductCode("P3"));
//
//            _exampleProductMap = new ProductMap();
//            var products = _exampleProductMap.Products;
//
//            products.Add(_exampleProduct1, 120);
//            products.Add(_exampleProduct2, 25);
//            products.Add(_exampleProduct3, 240);
//        }
//
//        [TestMethod]
//        public void MultiplicationTest_OfCorrectMapAndPriceList_GivesCorrectMoneyObject()
//        {
//            var routePriceList = new RoutePriceList(
//                new PriceListId(
//                    Guid.NewGuid()
//                )
//            );
//
//            var priceList = routePriceList.PriceList;
//            
//            priceList.Add(_exampleProduct1, new Money
//            {
//                Amount = new decimal(2.35),
//                Currency = Currency.Pln
//            });
//
//            priceList.Add(_exampleProduct2, new Money
//            {
//                Amount = new decimal(2.35),
//                Currency = Currency.Pln
//            });
//
//            priceList.Add(_exampleProduct3, new Money
//            {
//                Amount = new decimal(0.40),
//                Currency = Currency.Pln
//            });
//
//            var money = _exampleProductMap * routePriceList;
//
//            Assert.IsTrue(money == new Money
//                {
//                    Amount = new Decimal(485.50),
//                    Currency = Currency.Pln
//                }
//            );
//        }

//        [TestMethod]
//        public void MultiplicationTest_OfIncompatibileMapAndPriceList_ThrowsAnError()
//        {
//
//            //price list with missing price of 3th product
//            var priceList = new RoutePriceList(new PriceListId(Guid.NewGuid()));
//            
//            priceList.PriceList.Add(exampleProduct1, new Money
//            {
//                Amount = new decimal(2.35),
//                Currency = Currency.PLN
//            });
//
//
//            {
//                PriceList = new System.Collections.Generic.Dictionary<Domain.Product.Product, Money>
//                {
//                    {
//                        product1,
//                        new Money
//                        {
//                            Amount = new Decimal(2.35),
//                            Currency = Currency.PLN
//                        }
//                    },
//                    {
//                        product2,
//                        new Money
//                        {
//                            Amount = new Decimal(4.30),
//                            Currency = Currency.PLN
//                        }
//                    }
//                }
//            };
//
//            try
//            {
//                var money = map * priceList;
//
//                throw new Exception("Unexpected success");
//            }
//            catch(Shared.Exceptions.MissingProductsInPriceListException ex)
//            {
//                Assert.IsNotNull(ex);
//            }
//        }
//    }
//}
