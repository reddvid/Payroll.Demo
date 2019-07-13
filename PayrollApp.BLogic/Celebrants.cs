using System;
using System.Collections.Generic;
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
                    .Where(x => x.BirthDate.Month == DateTime.Today.Month
                    && (x.BirthDate.Day == today + 1
                    || x.BirthDate.Day == today + 2
                    || x.BirthDate.Day == today + 3
                    || x.BirthDate.Day == today + 4
                    || x.BirthDate.Day == today + 5
                    || x.BirthDate.Day == today + 6
                    || x.BirthDate.Day == today + 7))
                    .ToList();

                return upcomingBirthdays;
            }
        }


    }
}
