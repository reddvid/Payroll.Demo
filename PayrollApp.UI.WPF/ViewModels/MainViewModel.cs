using PayrollApp.BLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApp.UI.WPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<Employee> _displayedList;

        public List<Employee> DisplayedList
        {
            get => _displayedList;
            set
            {
                if (value != _displayedList)
                {
                    _displayedList = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainViewModel()
        {
            var celebrants = new Celebrants();

            BirthdaysThisMonth = celebrants.CelebrantsThisMonth;
            BirthdaysToday = celebrants.CelebrantsToday;
            BirthdaysUpcoming = celebrants.UpcomingCelebrants;
        }

        public List<Employee> BirthdaysThisMonth { get; private set; }
        public List<Employee> BirthdaysToday { get; private set; }
        public List<Employee> BirthdaysUpcoming { get; private set; }

        public void SetBirthdaysList(int index)
        {
            switch (index)
            {
                case 0:
                    DisplayedList = BirthdaysToday;
                    break;
                case 1:
                    DisplayedList = BirthdaysUpcoming;
                    break;
                case 2:
                    DisplayedList = BirthdaysThisMonth;
                    break;
            }
                
        }
    }
}
