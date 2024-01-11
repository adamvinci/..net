using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication1.ViewModels;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    class EmployeeVM : INotifyPropertyChanged
    {

        private ObservableCollection<EmployeeModel> _employees;
        private List<String> titles;
        public List<OrderModel> _orders;
        private EmployeeModel _selectedEmployee;
        private NorthwindContext context = new NorthwindContext();

        public List<OrderModel> OrderList
        {
            get { return _orders = loadOrders(); }
        }
        public List<OrderModel> loadOrders()
        {
            List<OrderModel> orders = new List<OrderModel>();   
            if(SelectedEmployee != null)
            {
                foreach (var item in SelectedEmployee.Employee.Orders.TakeLast(3).ToList())
                {
                    orders.Add(new OrderModel(item, item.OrderDetails.Sum(o => o.UnitPrice)));
                }
            }
      
            return orders;  
        }
        public EmployeeModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set { _selectedEmployee = value; OnPropertyChanged("OrderList"); }
        }
        public ObservableCollection<EmployeeModel> EmployeesList
        {
            get { return _employees = _employees ?? loadEmployee(); }
        }

        public List<string> ListTitle
        {
            get { return titles = titles ?? loadTitle(); }
        }
        public ObservableCollection<EmployeeModel> loadEmployee()
        {
            ObservableCollection<EmployeeModel> employees = new ObservableCollection<EmployeeModel>();
            foreach(Employee emp in context.Employees)
            {
                employees.Add(new EmployeeModel(emp));
            }
            return employees;
        }

        public List<string> loadTitle()
        {
            List<string> employees = context.Employees.Select(x => x.TitleOfCourtesy).Distinct().ToList();
            return employees;
        }
        private DelegateCommand _addCommand;
        public DelegateCommand AddCommand
        {
            get { return _addCommand = _addCommand ?? new DelegateCommand(AddCommandeExecute); }
        }
        public void AddCommandeExecute()
        {
            EmployeeModel employeeModel = new EmployeeModel(new Employee());
            EmployeesList.Add(employeeModel);
            SelectedEmployee = employeeModel;
        }

        private DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand
        {
            get { return _saveCommand = _saveCommand ?? new DelegateCommand(SaveCommandExecute); }
        }
        public void SaveCommandExecute()
        {
            context.Add(SelectedEmployee.Employee);
            context.SaveChanges();
            MessageBox.Show("Employee added");
        }




        private DelegateCommand _removeEmploye;
        public DelegateCommand RemoveEmploye
        {
            get { return _removeEmploye = _removeEmploye ?? new DelegateCommand(RemoveEmployeeExecute); }
        }
        public void RemoveEmployeeExecute()
        {
            if(_selectedEmployee == null)
            {
                MessageBox.Show("Select an employee to remove");
            }
            else
            {
               EmployeesList.Remove(SelectedEmployee);
              /*  Employee empToDelete = context.Employees.FirstOrDefault(x => x.EmployeeId == SelectedEmployee.Employee.EmployeeId);
                context.Remove(empToDelete);
                context.SaveChanges();*/

            }
        }
        // Property changed standard handling
        public event PropertyChangedEventHandler PropertyChanged; // La view s'enregistera automatiquement sur cet event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); // On notifie que la propriété a changé
            }
        }

    }
}
