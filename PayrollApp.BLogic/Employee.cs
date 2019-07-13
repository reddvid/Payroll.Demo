using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PayrollApp.BLogic
{
    public class Employee
    {
        public Employee() : this(0)
        {

        }

        public Employee(int employeeId)
        {
            EmployeeId = employeeId;
        }

        public string EmployeeIdNumber
        {
            get
            {
                return "ID-00" + EmployeeId;
            }
        }

        public string Position { get; set; }

        public int EmployeeId { get; private set; }

        public string FullName
        {
            get
            {
                string fullName = LastName;
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(fullName))
                    {
                        fullName += ", ";
                    }

                    fullName += FirstName;

                    // Add middle initial (get first character of MiddleName) 
                    // ONLY IF middle name is NOT empty 
                    if (!string.IsNullOrWhiteSpace(MiddleName))
                    {
                        fullName += " " + MiddleName[0] + ".";
                    }

                }
                return fullName;
            }
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public bool IsValidEmailAddress
        {
            get
            {
                return Regex.IsMatch(EmailAddress, @"^[a-zA-Z\._0-9]+@[a-zA-Z]+.\w{2,3}$");
            }
        }

        public string PhoneNumber { get; set; }
        public bool IsValidPhoneNumber
        {
            get
            {
                return Regex.IsMatch(PhoneNumber, @"^(?:0|63|\+63)[8-9]\d{9}$");
            }
        }

        public Address Home { get; set; }
        public DateTime BirthDate { get; set; }

        public int Age
        {
            get
            {
                var timeSpan = DateTime.Today - BirthDate;

                return (int)(timeSpan.TotalDays / 365);
            }
        }


        public override string ToString()
        {
            return $"{this.FullName} {this.BirthDate:MMM dd, yyyy}";
        }
    }
}
