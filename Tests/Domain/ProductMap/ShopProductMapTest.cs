using System;
using Domain.ProductMaps;
using Domain.ProductMaps.Exceptions;
using Domain.ProductMaps.Shop;
using Domain.Shop;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.ProductMap
{
    /// <summary>
    /// Unit tests of ShopProductMap.
    /// </summary>
    [TestClass]
    public class ShopProductMapTest
    {
        private ShopProductMap _shopProductMap;
        private global::Domain.Shop.Shop _shop;
        private ProductMapId _productMapId;

        [TestInitialize]
        public void OnTestInitialize()
        {
            _productMapId = new ProductMapId(Guid.NewGuid());
            _shop = new global::Domain.Shop.Shop(new ShopId(Guid.NewGuid()));

            _shopProductMap = new ShopProductMap(
                _productMapId,
                _shop,
                ShopProductMapType.Order
            );
        }

        [TestMethod]
        public void HasShop()
        {
            Assert.IsTrue(
                _shop.SameIdentityAs(_shopProductMap.Shop)    
            );
        }

        [TestMethod]
        public void HasType()
        {
            Assert.IsTrue(
                _shopProductMap.Type.Equals(ShopProductMapType.Order)
            );
        }

        [TestMethod]
        public void NativeConstructor_WithWrongData_ShouldThrowException()
        {
            try
            {
                // ReSharper disable once ObjectCreationAsStatement
                new ShopProductMap(
                    _productMapId,
                    _shop,
                    "wrong"
                );
                throw new Exception("Unexpected success!");
            }
            catch (WrongShopProductMapTypeException e)
            {
                Assert.IsNotNull(e);
            }
        }

        [TestMethod]
        public void NativeConstructor_WithSameData_ShouldConstractSameObject()
        {
            Assert.IsTrue(
                _shopProductMap.SameIdentityAs(
                    new ShopProductMap(
                        _productMapId,
                        _shop,
                        "order"
                    )
                )
            );
        }
    }
}
