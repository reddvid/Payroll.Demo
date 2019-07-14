using PayrollApp.UI.WPF.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.UI.WPF.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
        }

        private static readonly string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\OneDrive\Documents\pr_users.mdf;Integrated Security=True;Connect Timeout=30";
        public bool HasContent { get; set; }
        public string UsernameBox { get; set; }
        public string PasswordBox { get; set; }

        public bool Authenticate(params string[] credentials)
        {
            bool isValidUser = false;

            try
            {
                using (var conn = new SqlConnection(CONNECTION_STRING))
                {
                    string query = "SELECT * FROM Users";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string dbUser = reader.GetString(1);
                                string dbPass = reader.GetString(2);
                                if (credentials[0] == dbUser
                                    && credentials[1] == dbPass)
                                {
                                    isValidUser = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return isValidUser;
        }
    }
}
