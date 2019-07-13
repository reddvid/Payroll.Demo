using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.BLogic
{
    public class EmployeeRepository
    {
        public List<Employee> RetrieveAll()
        {
            var employees = new List<Employee>();

            employees.Add(new Employee { FirstName = "David", LastName = "Ballesteros", BirthDate = new DateTime(1992, 6, 14) });
            employees.Add(new Employee { FirstName = "Mang", LastName = "Kanor", BirthDate = new DateTime(2004, 7, 13) });
            employees.Add(new Employee { FirstName = "Mang", LastName = "Tomas", BirthDate = new DateTime(2004, 7, 18) });

            return employees;
        }

        public Employee Retrieve(int employeeId)
        {
            var employee = new Employee(employeeId);

            // Temporary code
            if (employeeId == 1)
            {
                employee.FirstName = "David";
                employee.LastName = "Ballesteros";
            }

            return employee;
        }

        public bool Save(Employee employee)
        {
            return true;
        }

    }
}
