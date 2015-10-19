using System;
using Domain.Route;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
