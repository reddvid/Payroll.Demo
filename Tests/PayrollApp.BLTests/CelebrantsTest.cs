using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollApp.BLogic;
using PayrollApp.Common;

namespace PayrollApp.BLTests
{
    [TestClass]
    public class CelebrantsTest
    {
        List<Employee> fakeList;

        public CelebrantsTest()
        {
            fakeList = new List<Employee>
            {
                new Employee { FirstName = "Arnold", LastName = "Yap", BirthDate = new DateTime(2001, 3, 14) },
                new Employee { FirstName = "Bernie", LastName = "Bernal", BirthDate = DateTime.Today },
                new Employee { FirstName = "Sarah", MiddleName = "Lian", LastName = "Gani", BirthDate = new DateTime(1964, 7, 21) },
                new Employee { FirstName = "Felipe", LastName = "Marconi", BirthDate = new DateTime(1998, 8, 9) },
                new Employee { FirstName = "Sarim", LastName = "Cake", BirthDate = new DateTime(1984, 9, 11) },
            };
        }

        [TestMethod]
        public void BirthdaysToday()
        {
            var celebrants = new Celebrants(fakeList);

            int actual = celebrants.CelebrantsToday.Count;

            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void BirthdaysThisMonth()
        {
            var celebrants = new Celebrants(fakeList);

            int actual = celebrants.CelebrantsThisMonth.Count;

            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void BirthdaysUpcoming()
        {
            var celebrants = new Celebrants(fakeList);

            int actual = celebrants.UpcomingCelebrants.Count;

            Assert.AreEqual(3, actual);
        }
    }
}
