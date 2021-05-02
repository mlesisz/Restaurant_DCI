using Restaurant_DCI.Models;
using Restaurant_DCI.Roles;
using System.Collections.Generic;

namespace Restaurant_DCI.Contex
{
    public class BrowsingMenuContex
    {
        public IBrowsingMemuProduct Product { get; private set; }
        public DB_Entities Db { get; private set; }
        public BrowsingMenuContex(IBrowsingMemuProduct product, DB_Entities _db )
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