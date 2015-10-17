using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Structs;

namespace Tests.Shared.Structs
{
    [TestClass]
    public class MoneyTest
    {
        private Currency _currency;
        private decimal _amount;
        private Money _money;

        [TestInitialize]
        public void Initialize()
        {
            _currency = Currency.Pln;
            _amount = 10.23m;
            _money = new Money(_amount, _currency);
        }

        [TestMethod]
        public void TestHasCurrency()
        {
            Assert.AreEqual(_money.Currency, _currency);
        }

        [TestMethod]
        public void TestHasAmount()
        {
            Assert.AreEqual(_money.Amount, _amount);
        }

        [TestMethod]
        public void TestEquals_ShouldBeTrue()
        {
            var moneyToCompare = new Money(_amount, _currency);

            Assert.IsTrue(
                _money.Equals(moneyToCompare)
            );
        }

        [TestMethod]
        public void TestEquals_ShouldBeFalse()
        {
            var moneyToCompare = new Money(_amount, Currency.Eur);

            Assert.IsFalse(
                _money.Equals(moneyToCompare)
            );
        }

        [TestMethod]
        public void TestFromNative()
        {
            Assert.IsTrue(
                _money.Equals(
                    Money.FromNative(_amount, "Pln")
                )
            );
        }

        [TestMethod]
        public void TestEqualOperator_Equation_ShouldBeTrue()
        {
            Assert.IsTrue(
                Money.FromNative(10m, "Pln") == Money.FromNative(10m, "Pln")
            );
        }

        [TestMethod]
        public void TestEqualOperator_Equation_ShouldBeFalse()
        {
            Assert.IsFalse(
                Money.FromNative(15m, "Pln") == Money.FromNative(10m, "Pln")
            );
        }

        [TestMethod]
        public void TestNotEqual_Equation_ShouldBeTrue()
        {
            Assert.IsTrue(
                Money.FromNative(5m, "Pln") != Money.FromNative(6m, "Pln")
            );
        }

        [TestMethod]
        public void TestNotEqual_Equation_ShouldBeFalse()
        {
            Assert.IsFalse(
                Money.FromNative(5m, "Pln") != Money.FromNative(5m, "Pln")
            );
        }

        [TestMethod]
        public void TestAddOperator()
        {
            var sum = Money.FromNative(100m, "Eur") + Money.FromNative(50m, "Eur");
            Assert.IsTrue(
                sum == Money.FromNative(150m, "Eur")
            );
        }

        [TestMethod]
        public void TestSubtractOperator()
        {
            var difference = Money.FromNative(100.00m, "Eur") - Money.FromNative(50.00m, "Eur");

            Assert.IsFalse(
                difference == Money.FromNative(50m, "Eur")
            );
        }

        [TestMethod]
        public void TestMultiplificationOperator()
        {
            Assert.IsTrue(
                Money.FromNative(10m, "Eur") * 5 == Money.FromNative(50m, "Eur")
            );

            Assert.IsTrue(
                5 * Money.FromNative(10m, "Eur") == Money.FromNative(50m, "Eur")
            );
        }

        [TestMethod]
        public void TestDivisionOperator()
        {
            Assert.IsTrue(
                Money.FromNative(50m, "Eur")/10 == Money.FromNative(5m, "Eur")
            );
        }
    }
}
