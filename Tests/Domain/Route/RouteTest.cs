using System;
using System.Collections.Generic;
using Domain.Route;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Structs;

namespace Tests.Domain.Route
{
    /// <summary>
    /// Unit tests of Route.
    /// </summary>
    [TestClass]
    public class RouteTest
    {
        private global::Domain.Route.Route _route;

        [TestInitialize]
        public void OnTestInitialize()
        {
            _route = new global::Domain.Route.Route(new RouteName("Warsaw"));
        }

        [TestMethod]
        public void HasRouteName()
        {
            Assert.AreEqual(_route.RouteName, new RouteName("Warsaw"));
        }

        [TestMethod]
        public void HasShops()
        {
            Assert.IsInstanceOfType(_route.Shops, typeof (SortedList<DateTimePeriod, global::Domain.Shop.Shop>));
        }

        [TestMethod]
        public void SameEntityAs_ShouldBeFalse()
        {
            Assert.IsFalse(
                _route.SameIdentityAs(new global::Domain.Route.Route(new RouteName("Opoczno")))   
            );
        }

        [TestMethod]
        public void SameEntityAs_ShouldBeTrue()
        {
            Assert.IsTrue(
                _route.SameIdentityAs(new global::Domain.Route.Route(new RouteName("Warsaw")))    
            );
        }
    }
}
