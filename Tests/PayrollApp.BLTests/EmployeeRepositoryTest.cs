using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollApp.BLogic;

namespace PayrollApp.BLTests
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        List<Employee> fakeList;

        public EmployeeRepositoryTest()
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
        public void CountAllEmployees()
        {
            var employeeRepository = new EmployeeRepository(fakeList);

            int actual = employeeRepository.RetrieveAll.Count;

            Assert.AreEqual(fakeList.Count, actual);
        }

        [TestMethod]
        public void RetrieveValid()
        {
            var employeeRepository = new EmployeeRepository();
            var expected = new Employee(1)
            {
                FirstName = "David",
                LastName = "Ballesteros"
            };

            Assert.AreEqual(expected.FullName, employeeRepository.Retrieve(1).FullName);
        }
    }
}
