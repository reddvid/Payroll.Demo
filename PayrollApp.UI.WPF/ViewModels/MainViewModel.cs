using PayrollApp.BLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.UI.WPF.ViewModels
{
    public class MainViewModel
    {
        public List<Employee> BirthdaysThisMonth => new Celebrants().ThisMonth;
    }
}
