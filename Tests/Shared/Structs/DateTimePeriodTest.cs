using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Structs;

namespace Tests.Shared.Structs
{
    /// <summary>
    /// Unit tests of DateTimePeriod.
    /// </summary>
    [TestClass]
    public class DateTimePeriodTest
    {
        private DateTime _dateTime1;
        private DateTime _dateTime2;
        private DateTimePeriod _dateTimePeriod;

        [TestInitialize]
        public void OnTestInitialize()
        {
            _dateTime1 = new DateTime(2010, 1, 1);
            _dateTime2 = new DateTime(2014, 1, 1);
            _dateTimePeriod = new DateTimePeriod(_dateTime1, _dateTime2);
        }

        [TestMethod]
        public void HasFrom()
        {
            Assert.IsTrue(
                _dateTime1.Equals(_dateTimePeriod.From)
            );
        }

        [TestMethod]
        public void HasTo()
        {
            Assert.IsTrue(
                _dateTime2.Equals(_dateTimePeriod.To)
            );
        }

        [TestMethod]
        public void Equals_ShouldBeFalse()
        {
            Assert.IsFalse(
                _dateTimePeriod.Equals(new DateTimePeriod(_dateTime1, new DateTime(2015, 1, 1)))
            );
        }

        [TestMethod]
        public void Equals_ShouldBeTrue()
        {
            Assert.IsTrue(
                _dateTimePeriod.Equals(new DateTimePeriod(_dateTime1, _dateTime2))
            );
        }

        [TestMethod]
        public void Constructor_WithTimeSpan_ShouldGiveSameResult()
        {
            Assert.IsTrue(
                _dateTimePeriod.Equals(new DateTimePeriod(_dateTime1, _dateTime2 - _dateTime1))
            );
        }

        [TestMethod]
        public void IsIncluded_ShouldBeFalse()
        {
            Assert.IsFalse(
                _dateTimePeriod.IsIncluded(new DateTime(2009, 1, 1))
            );
        }

        [TestMethod]
        public void IsIncluded_ShouldBeTrue()
        {
            Assert.IsTrue(
                _dateTimePeriod.IsIncluded(new DateTime(2011, 1, 1))
            );
        }
    }
}
