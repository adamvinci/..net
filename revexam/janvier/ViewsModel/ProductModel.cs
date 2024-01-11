using janvier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace janvier.ViewsModel
{
    class ProductModel
    {
        private readonly Product _product;
        public ProductModel(Product product)
        {
            this._product = product;
        }
        public Product Product { get { return _product; } }
        public int ProductID { get { return _product.ProductId; } }
        public string ProductName { get { return _product.ProductName; } }
        public string Categorie { get { return _product.Category.CategoryName; } }
        public string Fournisseur { get { return _product.Supplier.ContactName; } }
    }
}
