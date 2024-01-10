using examjanier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examjanier.ViewModels
{
    internal class ProduitModel
    {
        private readonly Product _product;

        public ProduitModel(Product product)
        {
            this._product = product;
        }
        public Product Product { get { return _product; } }
        public int ProductId { get { return _product.ProductId; } }
        public string ProductName{ get { return _product.ProductName; } }
        public string Categorie { get { return _product.Category.CategoryName; } }
        public string Fournisseur { get { return _product.Supplier.ContactName; } }
    }
}
