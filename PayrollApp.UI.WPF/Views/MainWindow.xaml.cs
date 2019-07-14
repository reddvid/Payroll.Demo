using PayrollApp.BLogic;
using PayrollApp.UI.WPF.ViewModels;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PayrollApp.UI.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = ViewModel;

            InitializeFilter();

            LoadEmployees();

            btnAddEmployee.Click += BtnAddEmployee_Click;
        }

        public List<Employee> GetEmployeesFromRepository()
        {
            var employeeRepository = new EmployeeRepository();

            return employeeRepository.RetrieveAll;
        }

        private void LoadEmployees()
        {
            lvEmployees.ItemsSource = GetEmployeesFromRepository();
        }

        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var result = new AddEmployee().ShowDialog();

            if (result == false)
            {
                // Update ListView
                lvEmployees.ItemsSource = GetEmployeesFromRepository();
            }
        }

        private void InitializeFilter()
        {
            birthdaysFilter.ItemsSource = new List<string>
            {
                "Today",
                "Upcoming",
                "This Month",
            };
            // Set the event handler first so setting the index will trigger the event
            birthdaysFilter.SelectionChanged += BirthdaysFilter_SelectionChanged;
            birthdaysFilter.SelectedIndex = 0;
        }

        private void BirthdaysFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.SetBirthdaysList(birthdaysFilter.SelectedIndex);
        }
    }
}
