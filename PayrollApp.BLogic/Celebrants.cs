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
        List<Employee> DataSource;

        public Celebrants()
        {
        }

        public Celebrants(List<Employee> employees)
        {
            DataSource = employees;
        }

        public List<Employee> GetEmployeesFromRepository()
        {
            var employeeRepository = new EmployeeRepository();

            return employeeRepository.RetrieveAll;
        }

        public List<Employee> CelebrantsThisMonth
        {
            get
            {
                if (DataSource.Count == 0)
                {
                    DataSource = GetEmployeesFromRepository();
                }

                var birthDaysThisMonth = DataSource.Where(
                        x =>
                        x.BirthDate.Month == DateTime.Today.Month)
                    .ToList();
                return birthDaysThisMonth;
            }
        }
        public List<Employee> CelebrantsToday
        {
            get
            {
                if (DataSource.Count == 0)
                {
                    DataSource = GetEmployeesFromRepository();
                }

                var birthDaysToday = DataSource.Where(
                        x =>
                        x.BirthDate.Month == DateTime.Today.Month &&
                        x.BirthDate.Day == DateTime.Today.Day)
                        .ToList();
                return birthDaysToday;
            }
        }
        public List<Employee> UpcomingCelebrants
        {
            get
            {
                var today = DateTime.Today.Day;

                if (DataSource.Count == 0)
                {
                    DataSource = GetEmployeesFromRepository();
                }

                var upcomingBirthdays = DataSource.Where(
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
