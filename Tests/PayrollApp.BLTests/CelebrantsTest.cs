using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollApp.BLogic;

namespace PayrollApp.BLTests
{
    [TestClass]
    public class CelebrantsTest
    {
        [TestMethod]
        public void BirthdaysToday()
        {
            var celebrants = new Celebrants();
            Assert.AreEqual(1, celebrants.Today.Count);
        }

        [TestMethod]
        public void BirthdaysThisMonth()
        {
            var celebrants = new Celebrants();
            Assert.AreEqual(2, celebrants.ThisMonth.Count);
        }

        [TestMethod]
        public void BirthdaysUpcoming()
        {
            var celebrants = new Celebrants();
            Assert.AreEqual(1, celebrants.Upcoming.Count);
        }
    }
}
