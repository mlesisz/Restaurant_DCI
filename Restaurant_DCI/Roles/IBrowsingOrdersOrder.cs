using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant_DCI.Models;
using Restaurant_DCI.Contex;

namespace Restaurant_DCI.Roles
{
    public interface IBrowsingOrdersOrder
    {
    }

    public static class BrowsingOrdersOrderTraits 
    { 
        public static List<Order> FindOrders(this IBrowsingOrdersOrder order, IBrowsingOrdersChef chef, IBrowsingOrdersClient client, DB_Entities _db)
        {
            Order order_ = order as Order;
            if (chef != null && order_ != null)
            {
                
                return _db.Orders.Where(m => m.OrderState == order_.OrderState).ToList();

            }else if(client != null && order_ != null)
            {
                Account client_ = client as Account; 
                return _db.Orders.Where(m => m.UserId == client_.idUser).ToList();
            }
            return null;
        }
        public static Order FindOrder(this IBrowsingOrdersOrder order, DB_Entities _db)
        {
            Order order_ = order as Order;
            bool isReady = true; 
            if(order_ != null)
            {
                order_ = _db.Orders.FirstOrDefault(m => m.OrderId == order_.OrderId);
                order_.OrderItems = _db.OrderItems.Where(m => m.OrderId == order_.OrderId).ToList();
                foreach (var item in order_.OrderItems)
                {
                    if (item.Done == false)
                    {
                        isReady = false;
                    }
                    Product product = new Product { ProductId = item.ProductId };
                    item.Product = new BrowsingMenuContex(product, _db).FindProduct();
                }

            }
            if (isReady)
            {
                order_.OrderState = OrderState.Ready;
                _db.SaveChanges();
            }
            return order_;
        }
    }
}
