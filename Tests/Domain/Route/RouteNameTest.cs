using Domain.Route;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Route
{
    /// <summary>
    /// Unit tests of RouteName.
    /// </summary>
    [TestClass]
    public class RouteNameTest
    {
        private string _name;
        private RouteName _routeName;

        [TestInitialize]
        public void OnTestInitialize()
        {
            _name = "Example example";
            _routeName = new RouteName(_name);
        }

        [TestMethod]
        public void HasName()
        {
            Assert.AreEqual(_name, _routeName.Name);
        }

        [TestMethod]
        public void Equals_ShouldBeFalse()
        {
            Assert.IsFalse(
                _routeName.Equals(new RouteName("Other example"))
            );
        }

        [TestMethod]
        public void Equals_ShouldBeTrue()
        {
            Assert.IsTrue(
                _routeName.Equals(new RouteName("Example example"))
            );
        }
    }
}
