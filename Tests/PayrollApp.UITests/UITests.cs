using System;
using PayrollApp.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollApp.UI.WPF.Views;
using System.Data.SqlClient;
using System.Diagnostics;
using PayrollApp.UI.WPF.ViewModels;
using PayrollApp.BLogic;
using System.Collections.Generic;

namespace PayrollApp.UITests
{
    [TestClass]
    public class UITests
    {
        

        [TestMethod]
        public void Login()
        {
            var loginViewModel = new LoginViewModel();
            string username = "admin";
            string password = "admin01";
            bool isAuthenticatedUser = loginViewModel.Authenticate(username, password);

            Assert.IsTrue(isAuthenticatedUser);
        }

        [TestMethod]
        public void AddEmployee()
        {
            var employee = new Employee
            {
                FirstName = "David",
                MiddleName = "Ico",
                LastName = "Ballesteros",
            };


        }
    }
}
