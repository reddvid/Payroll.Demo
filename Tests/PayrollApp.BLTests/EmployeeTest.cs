using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollApp.BLogic;

namespace PayrollApp.BLTests
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void FullNameValid()
        {
            // -- Arrange
            var employee = new Employee
            {
                FirstName = "David",
                MiddleName = "Ico",
                LastName = "Ballesteros"
            };

            string expected = "Ballesteros, David I.";

            // -- Act
            string actual = employee.FullName;


            // -- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameNoMiddleInitial()
        {
            // - Arrange
            var employee = new Employee
            {
                FirstName = "David",
                LastName = "Ballesteros"
            };

            string expected = "Ballesteros, David";

            // - Act
            string actual = employee.FullName;

            // - Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PhoneNumberValid()
        {
            // Arrange
            var employee = new Employee
            {
                PhoneNumber = "+639159874221"
            };

            // Assert
            Assert.IsTrue(employee.IsValidPhoneNumber);
        }

        [TestMethod]
        public void EmailAddressValid()
        {
            // Arrange
            var employee = new Employee
            {
                EmailAddress = "david_ballesteros@outlook.com"
            };

            // Assert
            Assert.IsTrue(employee.IsValidEmailAddress);
        }

        [TestMethod]
        public void IsProperAge()
        {
            var employee = new Employee
            {
                BirthDate = new DateTime(1992, 6, 14)
            };

            var expected = 27;

            var actual = employee.Age;

            Assert.AreEqual(expected, actual);
        }

    }
}
