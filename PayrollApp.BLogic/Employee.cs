using System;
using System.Text.RegularExpressions;

namespace PayrollApp.BLogic
{
    public class Employee
    {
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
                return Regex.IsMatch(EmailAddress, @"^[a-zA-Z\._0-9]+@[a-zA-Z]+.(?:com|net|org)");
            }
        }

        public bool IsValidPhoneNumber
        {
            get
            {
                return Regex.IsMatch(PhoneNumber, @"^(?:0|63|\+63)[8-9]\d{9}");
            }
        }

        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            return base.ToString().Trim();
        }
    }
}
