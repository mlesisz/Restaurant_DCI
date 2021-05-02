using Restaurant_DCI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_DCI.Roles
{
    public interface IBrowsingMemuProduct
    {

    }

    public static class BrowsingMemuProductTraits
    {
        public static List<Product> FindProducts(this IBrowsingMemuProduct product, DB_Entities _db)
        {
            if(product is Product _product)
            {
                List<Product> products = _db.Products.Where(s => s.Category.Equals(_product.Category)).ToList();
                return products;
            }
            else
            {
                return null;
            }
            
        }
        public static Product FindProduct(this IBrowsingMemuProduct product, DB_Entities _db)
        {
            if (product is Product _product)
            {
                Product products = _db.Products.FirstOrDefault(s => s.ProductId == _product.ProductId);
                return products;
            }
            else
            {
                return null;
            }
        }
    }
}
