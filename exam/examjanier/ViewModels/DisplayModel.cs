using examjanier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examjanier.ViewModels
{
    public class DisplayModel
    {
        private string _country;
        private decimal total = 0;


        public DisplayModel(string country, decimal total)
        {
            _country = country;
            this.total = total;
        }
        public String Country
        {
            get { return _country; }
        }
        public decimal Nb
        {
            get { return total; }
        }

    }
}
