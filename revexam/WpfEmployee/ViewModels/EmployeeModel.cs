using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    class EmployeeModel : INotifyPropertyChanged
    {
        // Property changed standard handling
        public event PropertyChangedEventHandler PropertyChanged; // La view s'enregistera automatiquement sur cet event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); // On notifie que la propriété a changé
            }
        }

        private readonly Employee _employee;
        public EmployeeModel(Employee employee)
        {
        this._employee = employee;
        }
        public Employee Employee { get { return _employee; } }
        public string LastName { get { return _employee.LastName; } set {_employee.LastName =value;OnPropertyChanged("FullName"); } }
        public string FirstName { get { return _employee.FirstName; } set { _employee.FirstName = value; OnPropertyChanged("FullName"); } }
        public string FullName { get { return _employee.LastName + " "+_employee.FirstName; } }
        public string TitleOfCourtesy { get { return _employee.TitleOfCourtesy; } set { _employee.TitleOfCourtesy = value; } }

        public DateTime? BirthDate { get { return _employee.BirthDate; } set { _employee.BirthDate = value; } }
        public string DisplayBirthDate { get { return _employee.BirthDate != null ? _employee.BirthDate.Value.ToShortDateString() : " "; } }

        public DateTime? HireDate { get { return _employee.HireDate; } set { _employee.HireDate = value; } }
    }
}
