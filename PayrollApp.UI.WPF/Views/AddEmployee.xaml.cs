using PayrollApp.BLogic;
using PayrollApp.UI.WPF.ViewModels;
using System;
using System.Windows;
using RandomNameGeneratorLibrary;
using System.Diagnostics;

namespace PayrollApp.UI.WPF.Views
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddViewModel ViewModel { get; } = new AddViewModel();

        public AddEmployee()
        {
            InitializeComponent();

            btnSave.Click += BtnSave_Click;

#if DEBUG
            InsertRandomTexts();
#endif
        }

        private void InsertRandomTexts()
        {
            var number = new Random().Next(18, 50);
            dpBirthdate.SelectedDate = new DateTime(DateTime.Today.Year - number, 6, 14);

            var personNameGenerator = new PersonNameGenerator();
            txFirstName.Text = personNameGenerator.GenerateRandomFirstName();
            txLastName.Text = personNameGenerator.GenerateRandomLastName();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(dpBirthdate.SelectedDate.Value.Date);

            var employee = new Employee
            {
                FirstName = txFirstName.Text,
                MiddleName = txMiddleName.Text,
                LastName = txLastName.Text,
                BirthDate = dpBirthdate.SelectedDate.Value.Date,
            };

            var employeeRepository = new EmployeeRepository();

            if (employee.Validate())
            {
                bool result = employeeRepository.Save(employee);

                if (result == true)
                {
                    this.Close();
                }
            }

        }
    }
}
