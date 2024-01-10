using examjanier.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication1.ViewModels;

namespace examjanier.ViewModels
{
    internal class ProduitVM 
    {
   

        private ObservableCollection<ProduitModel> _listProduits;
        private List<DisplayModel> _listProduitsVenduParPays;
        private NorthwindContext context = new NorthwindContext();
        private ProduitModel _selectedProduit;
        public ProduitModel SelectedProduit
        {
            get { return _selectedProduit; } set { _selectedProduit = value; }
        }

        public List<DisplayModel> ListProduitPays
        {
            get { return _listProduitsVenduParPays = _listProduitsVenduParPays ?? _loadProductPerPays(); }
        }
        public ObservableCollection<ProduitModel> ListProduit
        {
            get { return _listProduits = _listProduits ?? _loadProduct(); }
        }
        private ObservableCollection<ProduitModel> _loadProduct()
        {
            ObservableCollection<ProduitModel> locaList = new ObservableCollection<ProduitModel>();
            foreach (var item in context.Products.Where(p=>p.Discontinued==false))
            {
                locaList.Add(new ProduitModel(item));   
            }
            return locaList;
        }

        private List<DisplayModel> _loadProductPerPays()
        {
            List<DisplayModel> locaList = new List<DisplayModel>();
            var NombreproduitParPays = (from product in context.Products
                                        where product.OrderDetails.Count() > 0
                                        group product by product.Supplier.Country);
            foreach (var item in NombreproduitParPays)
            {
                locaList.Add(new DisplayModel(item.Key, item.Count()));
            }
            locaList = locaList.OrderByDescending(p => p.Nb).ToList();
            return locaList;
        }
        private DelegateCommand _abandonnerProduit;
        public DelegateCommand Abandonner
        {
            get { return _abandonnerProduit = _abandonnerProduit ?? new DelegateCommand(AbandonnerProduitMethod); }
        }
        public void AbandonnerProduitMethod()
        {
        SelectedProduit.Product.Discontinued = true;
            context.SaveChanges();
            ListProduit.Remove(SelectedProduit);
            MessageBox.Show("Product Discontinued");
        }
    }
}
