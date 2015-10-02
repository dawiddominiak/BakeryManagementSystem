using System;
using Domain.ProductMaps;
using Domain.PriceLists;
using Domain.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainUnitTests
{
    [TestClass]
    public class PriceListsOperatorTests
    {
        [TestMethod]
        public void MultiplicationTest_OfCorrectMapAndPriceList_GivesCorrectMoneyObject()
        {
            var product1 = new Domain.Product.ProductEntity { };
            var product2 = new Domain.Product.ProductEntity { };
            var product3 = new Domain.Product.ProductEntity { };

            var map = new ProductMapEntity
            {
                Products = new System.Collections.Generic.Dictionary<Domain.Product.ProductEntity, int>
                {
                    {
                        product1, 120
                    },
                    {
                        product2, 25
                    },
                    {
                        product3, 240
                    }
                }
            };

            var priceList = new RoutePriceList()
            {
                PriceList = new System.Collections.Generic.Dictionary<Domain.Product.ProductEntity, Money>
                {
                    {
                        product1,
                        new Money
                        {
                            Amount = new Decimal(2.35),
                            Currency = Currency.PLN
                        }
                    },
                    {
                        product2,
                        new Money
                        {
                            Amount = new Decimal(4.30),
                            Currency = Currency.PLN
                        }
                    },
                    {
                        product3,
                        new Money
                        {
                            Amount = new Decimal(0.40),
                            Currency = Currency.PLN
                        }
                    }
                }
            };

            var money = map * priceList;

            Assert.IsTrue(money == new Money
                {
                    Amount = new Decimal(485.50),
                    Currency = Currency.PLN
                }
            );
        }

        [TestMethod]
        public void MultiplicationTest_OfIncompatibileMapAndPriceList_ThrowsAnError()
        {
            var product1 = new Domain.Product.ProductEntity { };
            var product2 = new Domain.Product.ProductEntity { };
            var product3 = new Domain.Product.ProductEntity { };

            var map = new ProductMapEntity
            {
                Products = new System.Collections.Generic.Dictionary<Domain.Product.ProductEntity, int>
                {
                    {
                        product1, 120
                    },
                    {
                        product2, 25
                    },
                    {
                        product3, 240
                    }
                }
            };

            //price list with missing price of 3th product
            var priceList = new RoutePriceList()
            {
                PriceList = new System.Collections.Generic.Dictionary<Domain.Product.ProductEntity, Money>
                {
                    {
                        product1,
                        new Money
                        {
                            Amount = new Decimal(2.35),
                            Currency = Currency.PLN
                        }
                    },
                    {
                        product2,
                        new Money
                        {
                            Amount = new Decimal(4.30),
                            Currency = Currency.PLN
                        }
                    }
                }
            };

            try
            {
                var money = map * priceList;

                throw new Exception("Unexpected success");
            }
            catch(Domain.Exceptions.MissingProductsInPriceListException ex)
            {
                Assert.IsNotNull(ex);
            }
        }
    }
}
