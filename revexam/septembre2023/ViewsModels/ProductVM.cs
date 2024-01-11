using septembre2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication1.ViewModels;

namespace septembre2023.ViewsModels
{
    class ProductVM
    {
        private List<ProductModel> _products;
    private Dictionary<int,decimal> _totalVentesPerProduct;
        private NorthwindContext context = new NorthwindContext();
        
        
        public List<ProductModel> Products {  get { return _products = _products ?? loadProducts(); } }
        private List<ProductModel> loadProducts()
        {
            List<ProductModel> productModels = new List<ProductModel>();    
            foreach(Product product in context.Products)
            {
                productModels.Add(new ProductModel(product));
            }
            return productModels;
        }
        public Dictionary<int, decimal> TotalVentes
        {
            get { return _totalVentesPerProduct = _totalVentesPerProduct ?? loadTotalVentes(); }
        }
        private Dictionary<int,decimal> loadTotalVentes()
        {
            Dictionary<int,decimal> keyValuePairs = new Dictionary<int,decimal>();
            foreach(Product product in context.Products)
            {
                keyValuePairs.Add(product.ProductId,product.OrderDetails.Sum(o=>o.Quantity*o.UnitPrice));
            }
            return keyValuePairs;
        }
        private DelegateCommand _updateCommand;
        public DelegateCommand UpdateCommand
        {
            get { return _updateCommand = _updateCommand ?? new DelegateCommand(UpdateFunction); }
        }
        public void UpdateFunction()
        {
            context.SaveChanges();
            MessageBox.Show("Change saved");
        }
    }
}
