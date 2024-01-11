using janvier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace janvier.ViewsModel
{
    class ProductPerCountryModel
    {
        private string _country;
        private int _totalSales;
        public ProductPerCountryModel(String country,int totalSales)
        {
            this._country = country;
            this._totalSales = totalSales;  
        }
        public String Country { get { return _country; } }  
        public int TotalSales { get { return _totalSales; } }
    }
}
