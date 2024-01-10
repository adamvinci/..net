using examseptembbre.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication1.ViewModels;

namespace examseptembbre.ViewModels
{
    class ProductVM
    {
        private List<ProductModel> products;
        private Dictionary<int, string> _totalVente;
        private NorthwindContext context = new NorthwindContext();

        public List<ProductModel> Products
        {
            get { return products = products ?? loadProducts(); }
        }
        private List<ProductModel> loadProducts()
        {
            List<ProductModel> localList = new List<ProductModel> ();
            foreach(Product product in context.Products)
            {
                localList.Add(new ProductModel(product));
            }
            return localList;
        }
        public Dictionary<int, string> TotalVente
        {
            get { return _totalVente = _totalVente ?? loadTotalVente(); }
        }
        private Dictionary<int,string> loadTotalVente()
        {
            Dictionary<int, string> localMap = new Dictionary<int, string> ();
                        
            foreach(Product p in context.Products)
            {
                localMap.Add(p.ProductId, p.OrderDetails.Sum(o => o.UnitPrice * o.Quantity).ToString());
            }
            return localMap;
        }
        private DelegateCommand _majCommand;
        public DelegateCommand UpdateProduct
        {

            get { return _majCommand = _majCommand ?? new DelegateCommand(Update); }
        }
        private void Update()
        {
            context.SaveChanges();
            MessageBox.Show("updated");
        }
    }
}
