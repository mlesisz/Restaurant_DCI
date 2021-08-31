using Restaurant_DCI.Models;
using Restaurant_DCI.RoleMethods;
using System.Collections.Generic;

namespace Restaurant_DCI.Contex
{
    public class BrowsingMenuContex
    {
        #region Roles and RolesInterfaces
        public interface IProduct { }
        public IProduct Product { get; private set; }
        #endregion

        public DB_Entities Db { get; private set; }
        public BrowsingMenuContex(IProduct product, DB_Entities _db )
        {
            Product = product;
            Db = _db;
        }
        public List<Product> FindProducts()
        {
            return Product.FindProducts(Db);
        }
        public Product FindProduct()
        {
            return Product.FindProduct(Db);
        }
    }
}