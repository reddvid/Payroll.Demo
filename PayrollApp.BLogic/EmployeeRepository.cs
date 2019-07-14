using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.BLogic
{
    public class EmployeeRepository
    {
        private static readonly string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\OneDrive\Documents\pr_users.mdf;Integrated Security=True;Connect Timeout=30";

        public List<Employee> RetrieveAll()
        {
            var employees = new List<Employee>();

            try
            {
                using (var conn = new SqlConnection(CONNECTION_STRING))
                {
                    string query = "SELECT * FROM Employees";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Debug.WriteLine(reader.GetDateTime(4));

                                employees.Add(new Employee
                                {
                                    FirstName = reader.GetString(1),
                                    MiddleName = reader.GetString(2),
                                    LastName = reader.GetString(3),
                                    BirthDate = reader.GetDateTime(4)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            //employees.Add(new Employee { FirstName = "David", LastName = "Ballesteros", BirthDate = new DateTime(1992, 6, 14) });
            //employees.Add(new Employee { FirstName = "Mang", LastName = "Kanor", BirthDate = new DateTime(2004, 7, 13) });
            //employees.Add(new Employee { FirstName = "Mang", LastName = "Tomas", BirthDate = new DateTime(2004, 7, 18) });

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
            bool isSuccess = true;
            try
            {
                using (var conn = new SqlConnection(CONNECTION_STRING))
                {
                    string query = "INSERT INTO Employees (FirstName, MiddleName, LastName, BirthDate) VALUES (@firstname, @middlename, @lastname, @birthdate)";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@firstname", employee.FirstName);
                        command.Parameters.AddWithValue("@middlename", employee.MiddleName);
                        command.Parameters.AddWithValue("@lastname", employee.LastName);
                        command.Parameters.AddWithValue("@birthdate", employee.BirthDate);

                        conn.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                        {
                            isSuccess = false;
                            Debug.WriteLine("Error inserting data into Database!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return isSuccess;
        }

    }
}
