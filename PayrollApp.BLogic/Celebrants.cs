using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.BLogic
{
    public class Celebrants
    {
        public Celebrants()
        {

        }

        public Celebrants(Employee employee)
        {

        }

        public List<Employee> ThisMonth
        {
            get
            {
                var employeeRepository = new EmployeeRepository();
                var birthDaysThisMonth = employeeRepository.RetrieveAll()
                    .Where(x => x.BirthDate.Month == DateTime.Today.Month).ToList();
                return birthDaysThisMonth;
            }
        }
        public List<Employee> Today
        {
            get
            {
                var employeeRepository = new EmployeeRepository();
                var birthDaysToday = employeeRepository.RetrieveAll()
                    .Where(x
                    => x.BirthDate.Month == DateTime.Today.Month
                    && x.BirthDate.Day == DateTime.Today.Day)
                    .ToList();
                return birthDaysToday;
            }
        }
        public List<Employee> Upcoming
        {
            get
            {
                var employeeRepository = new EmployeeRepository();
                var today = DateTime.Today.Day;

                var upcomingBirthdays = employeeRepository.RetrieveAll()
                    .Where(
                        x => (x.BirthDate.Month == DateTime.Today.Month &&
                        x.BirthDate.Day < DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) &&
                        x.BirthDate.Day > DateTime.Today.Day) || 
                        x.BirthDate.Month > DateTime.Today.Month)
                    .ToList();

                return upcomingBirthdays;
            }
        }


    }
}
