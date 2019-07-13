using PayrollApp.UI.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PayrollApp.UI.WPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginViewModel ViewModel { get; } = new LoginViewModel();

        public LoginWindow()
        {
            InitializeComponent();

            this.DataContext = ViewModel;

            btnLogin.Click += BtnLogin_Click;

#if DEBUG
            txUser.Text = "admin";
            txPassword.Password = "admin01";
#endif
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txUser.Text) &&
                !string.IsNullOrWhiteSpace(txPassword.Password))
            {
                // Connect and check database
                string cx = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\OneDrive\Documents\pr_users.mdf;Integrated Security=True;Connect Timeout=30";

                try
                {
                    using (var conn = new SqlConnection(cx))
                    {
                        conn.Open();

                        if (conn.State == System.Data.ConnectionState.Open)
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandText = "SELECT * FROM Users";
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        string dbUser = reader.GetString(1);
                                        string dbPass = reader.GetString(2);
                                        if (txUser.Text == dbUser
                                            && txPassword.Password == dbPass)
                                        {
                                            // Go to MainWindow - must break
                                            new MainWindow().Show();
                                            this.Close();
                                        }
                                        else if (!txUser.Text.Equals(dbUser)
                                                 || !txPassword.Password.Equals(dbPass))
                                        {
                                            // Wrong username or password
                                            continue;
                                        }
                                        else
                                        {
                                            // Wrong username or password
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception eSql)
                {
                    Debug.WriteLine("Exception: " + eSql.Message);
                }
            }
            else
            {
                // Prompt for empty box
            }
        }
    }
}
