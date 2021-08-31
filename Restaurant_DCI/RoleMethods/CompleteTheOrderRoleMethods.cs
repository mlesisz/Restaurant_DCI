using Restaurant_DCI.Models;
using System.Linq;
using Restaurant_DCI.Contex;

namespace Restaurant_DCI.RoleMethods
{
    
    public static class CompleteTheOrderRoleMethods
    {
        public static void Make(this CompleteTheOrderContex.IOrderItem orderItem, DB_Entities _db)
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
