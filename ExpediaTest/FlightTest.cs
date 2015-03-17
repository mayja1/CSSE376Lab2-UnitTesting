using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
		[Test]
        public void TestThatFlightInitializes()
        {
            DateTime startDate = new DateTime(2009, 11, 1);
		    DateTime endDate = new DateTime(2009, 11, 30);
            Assert.NotNull(new Flight(startDate, endDate, 100));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightDoesNotAllowInvalidDates()
        {
            DateTime endDate = new DateTime(2009, 11, 1);
            DateTime startDate = new DateTime(2009, 11, 30);
            new Flight(startDate, endDate, 100);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightDoesNotAllowNegativeMiles()
        {
            DateTime startDate = new DateTime(2009, 11, 1);
            DateTime endDate = new DateTime(2009, 11, 30);
            new Flight(startDate, endDate, -1);
        }

        [Test]
        public void TestFlightPriceForOneDay()
        {
            DateTime startDate = new DateTime(2009, 11, 1);
            DateTime endDate = new DateTime(2009, 11, 2);
            Flight f = new Flight(startDate, endDate, 100);
            Assert.AreEqual((200 + 1*20), f.getBasePrice());
        }

        [Test]
        public void TestFlightPriceForTwoDays()
        {
            DateTime startDate = new DateTime(2009, 11, 1);
            DateTime endDate = new DateTime(2009, 11, 3);
            Flight f = new Flight(startDate, endDate, 100);
            Assert.AreEqual((200 + 2 * 20), f.getBasePrice());
        }

        [Test]
        public void TestFlightPriceForTenDays()
        {
            DateTime startDate = new DateTime(2009, 11, 1);
            DateTime endDate = new DateTime(2009, 11, 11);
            Flight f = new Flight(startDate, endDate, 100);
            Assert.AreEqual((200 + 10 * 20), f.getBasePrice());
        }

        [Test]
        public void TestObjectEqualsMethod()
        {
            DateTime startDate = new DateTime(2009, 11, 1);
            DateTime endDate = new DateTime(2009, 11, 2);
            Flight f = new Flight(startDate, endDate, 100);
            Assert.IsTrue(f.Equals(f as Object));
        }

        [Test]
        public void TestFlightEqualsMethod()
        {
            DateTime startDate = new DateTime(2009, 11, 1);
            DateTime endDate = new DateTime(2009, 11, 2);
            Flight f = new Flight(startDate, endDate, 100);
            Flight f2 = new Flight(startDate, endDate, 100);
            Assert.IsTrue(f.Equals(f2));
        }
	}
}
