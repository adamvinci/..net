using janvier.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication1.ViewModels;

namespace janvier.ViewsModel
{
    class ProductVM
    {
        private ObservableCollection<ProductModel> _products;
        private List<ProductPerCountryModel> _productsPerCountry;
        private NorthwindContext context = new NorthwindContext();
        private ProductModel _selectedProduct;
        public ProductModel SelectedProduct { get { return _selectedProduct; } set { _selectedProduct = value; } }

        public ObservableCollection<ProductModel> Products
        {
            get { return _products = _products ?? loadProducts(); }
        }
        public ObservableCollection<ProductModel> loadProducts()
        {
             ObservableCollection<ProductModel> productModels = new ObservableCollection<ProductModel>();    
        foreach(Product product in context.Products)
            {
                productModels.Add(new ProductModel(product));
            }
        return productModels;
        }

        public List<ProductPerCountryModel> ProductPerCountry
        {
            get { return _productsPerCountry = _productsPerCountry ?? loadProductPerCountry(); }
        }

        private List<ProductPerCountryModel> loadProductPerCountry()
        {
            List<ProductPerCountryModel> productPerCountryModels =
                context.Products.AsEnumerable().GroupBy(p=>p.Supplier.Country).Select(e=>new ProductPerCountryModel(e.Key,e.Count())).OrderByDescending(result=>result.TotalSales).ToList();
            return productPerCountryModels;
        }

        private DelegateCommand _abandonnerProduit;
        public DelegateCommand AbandonnerProduit
        {
            get { return _abandonnerProduit = _abandonnerProduit ?? new DelegateCommand(AbandonnerProduitMethode); }
        }
        private void AbandonnerProduitMethode()
        {
            if(SelectedProduct != null)
            {
                SelectedProduct.Product.Discontinued = true;
                context.SaveChanges();
                Products.Remove(SelectedProduct);
                MessageBox.Show("product discontiued");
            }
            else { MessageBox.Show("You have to select a product first"); }
        }
    }
}
