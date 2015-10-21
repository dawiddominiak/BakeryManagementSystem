using System;
using Domain.ProductMaps;
using Domain.ProductMaps.Exceptions;
using Domain.ProductMaps.Route;
using Domain.Route;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.ProductMap
{
    /// <summary>
    /// Unit tests of RouteProductMap.
    /// </summary>
    [TestClass]
    public class RouteProductMapTest
    {
        private RouteProductMap _routeProductMap;
        private global::Domain.Route.Route _route;
        private ProductMapId _productMapId;

        [TestInitialize]
        public void OnTestInitialize()
        {
            _productMapId = new ProductMapId(Guid.NewGuid());
            _route = new global::Domain.Route.Route(new RouteName("RN"));

            _routeProductMap = new RouteProductMap(
                _productMapId,
                _route,
                RouteProductMapType.WarehouseIssue
            );
        }

        [TestMethod]
        public void HasShop()
        {
            Assert.IsTrue(
                _route.SameIdentityAs(_routeProductMap.Route)
            );
        }

        [TestMethod]
        public void HasType()
        {
            Assert.IsTrue(
                _routeProductMap.Type.Equals(RouteProductMapType.WarehouseIssue)
            );
        }

        [TestMethod]
        public void NativeConstructor_WithWrongData_ShouldThrowException()
        {
            try
            {
                // ReSharper disable once ObjectCreationAsStatement
                new RouteProductMap(
                    _productMapId,
                    _route,
                    "wrong"
                );
                throw new Exception("Unexpected success!");
            }
            catch (WrongRouteProductMapTypeException e)
            {
                Assert.IsNotNull(e);
            }
        }
        
        [TestMethod]
        public void NativeConstructor_WithSameData_ShouldConstractSameObject()
        {
            Assert.IsTrue(
                _routeProductMap.SameIdentityAs(
                    new RouteProductMap(
                        _productMapId,
                        _route,
                        "warehouseissue"
                    )
                )
            );
        }
    }
}
