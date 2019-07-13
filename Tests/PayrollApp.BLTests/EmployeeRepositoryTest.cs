using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollApp.BLogic;

namespace PayrollApp.BLTests
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        [TestMethod]
        public void CountAllEmployees()
        {
            var employeeRepository = new EmployeeRepository();

            Assert.AreEqual(1, employeeRepository.RetrieveAll().Count);
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
