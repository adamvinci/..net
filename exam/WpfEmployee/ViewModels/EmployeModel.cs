using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    class EmployeModel : INotifyPropertyChanged
    {
        private readonly Employee employee;
        public EmployeModel(Employee employee)
        {
            this.employee = employee;
        }
        public Employee Employee { get { return employee; } }
        public string LastName
        {
            get {  return employee.LastName; } set { employee.LastName = value; OnPropertyChanged("FullName"); }
        }
        public string FirstName
        {
            get { return employee.FirstName; } set { employee.FirstName = value; OnPropertyChanged("FullName"); }
          
        }
        public string FullName
        {
            get { return employee.FirstName + " " + employee.LastName; }
        }
        public string TitleOfCourtesy
        {
            get { return employee.TitleOfCourtesy; } set { employee.TitleOfCourtesy = value; }
        }
        public DateTime? BirthDate
        {
            get { return employee.BirthDate; } set { employee.BirthDate = value; }
        }

        public DateTime? HireDate
        {
            get { return employee.HireDate; }
            set { employee.HireDate = value; }
        }
        public String DisplayBirthDate
        {
            get
            {
                if(employee.BirthDate.HasValue)
                {
                    return employee.BirthDate.Value.ToShortDateString();
                }
                return " ";
            }
                         
        }

        public String DisplayHireDate
        {
            get
            {
                if (employee.HireDate.HasValue)
                {
                    return employee.HireDate.Value.ToShortDateString();
                }
                return " ";
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
