using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollApp.BLogic;

namespace PayrollApp.BLTests
{
	[TestClass]
	public class EmployeeTest
	{
		[TestMethod]
		public void TestFullName()
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
		public void TestFullNameNoMiddleInitial()
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
		public void TestPhoneNumberValid()
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
		public void TestEmailAddressValid()
		{
			// Arrange
			var employee = new Employee
			{
				EmailAddress = "david_ballesteros12@outlook.com"
			};

			// Assert
			Assert.IsTrue(employee.IsValidEmailAddress);
		}
	}
}
