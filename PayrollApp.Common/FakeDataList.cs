using PayrollApp.BLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.Common
{
    public class FakeDataList
    {
        public List<Employee> FakeDataBank
        {
            get
            {
                List<Employee> fakeList = new List<Employee>
                {
                    new Employee { FirstName = "Arnold", LastName = "Yap", BirthDate = new DateTime(1964, 3, 21) },
                    new Employee { FirstName = "Sarah", MiddleName = "Lian", LastName = "Gani", BirthDate = new DateTime(1964, 7, 21) },
                    new Employee { FirstName = "Arnold", LastName = "Yap", BirthDate = new DateTime(1964, 3, 21) },
                };

                return fakeList;
            }
        }
    }
}
