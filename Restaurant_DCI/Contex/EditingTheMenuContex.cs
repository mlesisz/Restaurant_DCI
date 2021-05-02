using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant_DCI.Models;
using Restaurant_DCI.Roles;

namespace Restaurant_DCI.Contex
{
    public class EditingTheMenuContex
    {
        public DB_Entities Db { get; private set; }
        public IEditingTheMenuProduct Product { get; set; }
        public EditingTheMenuContex(IEditingTheMenuProduct product, DB_Entities _db )
        {
            Db = _db;
            Product = product;
        }

        public bool AddProduct()
        {
            return Product.AddProduct(Db);
        }
        public bool EditProduct()
        {
            return Product.EditProduct(Db);
        }
        public bool RemoveProduct()
        {
            return Product.RemoveProduct(Db);
        }
    }
}