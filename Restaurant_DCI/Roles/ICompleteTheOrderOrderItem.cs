using Restaurant_DCI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_DCI.Roles
{
    public interface ICompleteTheOrderOrderItem
    {
    }

    public static class CompleteTheOrderOrderItemTraits
    {
        public static void Make(this ICompleteTheOrderOrderItem orderItem, DB_Entities _db)
        {
            OrderItem orderItem_ = orderItem as OrderItem;
            if(orderItem_ != null)
            {
                OrderItem orderItemDB = _db.OrderItems.FirstOrDefault(m => m.OrderItemId == orderItem_.OrderItemId);
                orderItemDB.Done = !orderItemDB.Done;
                Order order = _db.Orders.FirstOrDefault(m => m.OrderId == orderItemDB.OrderId);
                if(order.OrderState == OrderState.New)
                {
                    order.OrderState = OrderState.InProgress;
                }
                _db.SaveChanges();
            }
        }
    }
}
