using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant_DCI.Models;

namespace Restaurant_DCI.Roles
{
    public interface IPlaceAnOrderOrderPlaced
    {
    }

    public static class PlaceAnOrderOrderPlacedTraits
    {
        public static bool SaveOrder(this IPlaceAnOrderOrderPlaced orderPlaced, ISessionManager session, DB_Entities _db)
        {
            List<CartItem> cart = session.GetCart();
            if(orderPlaced is Order order)
            {
                order.UserId = session.Get<int>("idUser");
                order.DateCreated = DateTime.Now;
                order.OrderItems = new List<OrderItem>();
                order.TotalPrice = 0;
                order.OrderState = OrderState.New;

                _db.Orders.Add(order);

                foreach (var item in cart)
                {
                    var newOrderItem = new OrderItem()
                    {
                        ProductId = item.Product.ProductId,
                        Quantity = item.Quantity,
                        Price = item.TotalPrice,
                        OrderId = order.OrderId,
                        Done = false
                    };
                    order.TotalPrice += (item.Quantity * item.Product.Price );

                    _db.OrderItems.Add(newOrderItem);
                }

                _db.SaveChanges();
                cart.Clear();
                return true;
            }
            return false;
        }
    }
}
