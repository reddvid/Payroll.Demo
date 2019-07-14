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

namespace PayrollApp.UI.WPF.Views
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

            DataContext = ViewModel;

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
                try
                {
                    bool isValidUser = ViewModel.Authenticate(txUser.Text, txPassword.Password);

                    switch (isValidUser)
                    {
                        case true:
                            // Go to MainWindow
                            new MainWindow().Show();
                            Close();
                            break;
                        case false:
                            // Prompt wrong info input
                            errorMsg.Visibility = Visibility.Visible;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception: " + ex.Message);
                }
            }
            else
            {
                // Prompt for empty box
            }
        }
    }
}
