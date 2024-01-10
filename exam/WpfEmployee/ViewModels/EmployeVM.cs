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
    class EmployeVM : INotifyPropertyChanged
    {
        private ObservableCollection<EmployeModel> _employeList;
        private List<String> _titleList;
        private NorthwindContext context = new NorthwindContext();
        private List<OrderModel> orders;
        public List<OrderModel> ListOrders
        {
            get { return orders =  _loadOrder(); ; }
        }
        public List<OrderModel> _loadOrder()
        {
            List<OrderModel> orders = new List<OrderModel>();
            if (SelectedEmploye != null)
            {
                orders = SelectedEmploye.Employee.Orders.TakeLast(3).Select(order => new OrderModel(order,order.OrderDetails.Sum(o=>o.UnitPrice))).ToList();
      
            }
            
            return orders;
        }
        public ObservableCollection<EmployeModel> EmployeesList
        {
            get { return _employeList = _employeList ?? _loadEmploye(); }
        }
        public List<String> ListTitle
        {
            get { return _titleList = _titleList ?? _loadTitle(); }
        }
        private List<String> _loadTitle()
        {
            List<String> list = new List<String>();
            list = context.Employees.Select(e => e.TitleOfCourtesy).Distinct().ToList();
            return list;

        }
        private ObservableCollection<EmployeModel> _loadEmploye()
        {
            ObservableCollection<EmployeModel> _employelocal = new ObservableCollection<EmployeModel>();
            foreach (Employee employee in context.Employees)
            {
                _employelocal.Add(new EmployeModel(employee));
            }
            return _employelocal;
        }
        public EmployeModel _SelectedEmploye;
        public EmployeModel SelectedEmploye
        {
            get { return _SelectedEmploye; }
            set { _SelectedEmploye = value;OnPropertyChanged("ListOrders"); }
        }
        private DelegateCommand _SaveCommand;
        private DelegateCommand _AddCommand;
        public DelegateCommand AddCommand
        {
            get { return _AddCommand = _AddCommand ?? new DelegateCommand(NewEmploye); }
        }
        public DelegateCommand SaveCommand
        {
            get { return _SaveCommand = _SaveCommand ?? new DelegateCommand(Save); }
        }
        private void NewEmploye()
        {
            Employee EGlobal = new Employee();
            EmployeModel EModel = new EmployeModel(EGlobal);
            EmployeesList.Add(EModel);
            SelectedEmploye = EModel;

            MessageBox.Show(_SelectedEmploye.FullName);
        }
        private void Save()
        {
            MessageBox.Show(_x);
            /* Employee verif = context.Employees.Where(e => e.EmployeeId == SelectedEmploye.Employee.EmployeeId).SingleOrDefault();
             if (verif != null)
             {
                 MessageBox.Show("bad request");

             }

             context.SaveChanges();
             MessageBox.Show("Enregistrement en base de données fait");*/

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private string _x;
        public string X
        {
            get { return _x; }
            set { _x = value;  }
        }
    }
}
