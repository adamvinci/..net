using septembre2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace septembre2023.ViewsModels
{
    class ProductModel
    {
        private readonly Product _product;
        public ProductModel(Product product)
        {
            this._product = product;
        }
        public int ProductID { get { return _product.ProductId; }  }
        public string ProductName {  get { return _product.ProductName; } set { _product.ProductName = value; } }
        public string SupplierContactName { get { return _product.Supplier.ContactName; }  }
        public string QuantityPerUnit {  get { return _product.QuantityPerUnit;} set { _product.QuantityPerUnit = value; } }
    }
}
