using PayrollApp.UI.WPF.ViewModels;
using System;
using System.Diagnostics;
using System.Windows;

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
            txPassword.PasswordChanged += TxPassword_PasswordChanged;

#if DEBUG
            txUser.Text = "admin";
            txPassword.Password = "admin01";
#endif
        }

        private void TxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            tbPasswordWatermark.Visibility = (string.IsNullOrEmpty(txPassword.Password)) ? Visibility.Visible : Visibility.Collapsed;
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
