using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    class OrderModel
    {
        private readonly Order _order;
        private decimal _total;
        public OrderModel(Order order,decimal OrderTotal)
        {
            this._order = order;
            this._total = OrderTotal;
        }
        public int OrderID { get { return _order.OrderId; } }
        public string OrderDate{ get { return _order.OrderDate !=null ? _order.OrderDate.Value.ToShortDateString() : "pas de date"; } }

        public decimal OrderTotal{ get { return _total; } }


    }
}
