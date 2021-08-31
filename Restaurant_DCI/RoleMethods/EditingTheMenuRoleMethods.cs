using Restaurant_DCI.Models;
using System.Linq;
using Restaurant_DCI.Contex;

namespace Restaurant_DCI.RoleMethods
{
    public static class EditingTheMenuRoleMethods
    {
        public static bool AddProduct(this EditingTheMenuContex.IProduct product, DB_Entities _db)
        {
            if (product is Product _product)
            {
                try
                {
                    _db.Products.Add(_product);
                    _db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool EditProduct(this EditingTheMenuContex.IProduct product, DB_Entities _db)
        {
            if (product is Product _product)
            {
                try
                {
                    var result = _db.Products.FirstOrDefault(p=>p.ProductId == _product.ProductId);
                    if(result != null)
                    {
                        result.Name = _product.Name;
                        result.Description = _product.Description;
                        result.Price = _product.Price;
                        result.Recipe = _product.Recipe;
                        _db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool RemoveProduct(this EditingTheMenuContex.IProduct product, DB_Entities _db)
        {
            if (product is Product _product)
            {
                try
                {
                    _db.Products.Remove(_product);
                    _db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
