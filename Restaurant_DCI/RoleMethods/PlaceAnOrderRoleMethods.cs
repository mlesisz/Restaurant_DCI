using System;
using System.Collections.Generic;
using Restaurant_DCI.Models;
using Restaurant_DCI.Contex;

namespace Restaurant_DCI.RoleMethods
{
    public static class PlaceAnOrderRoleMethods
    {
        public static List<CartItem> GetCart(this ISessionManager session)
        {
            List<CartItem> cart;
            if (session.Get<List<CartItem>>("CartItems") == null)
            {
                cart = new List<CartItem>();
            }
            else
            {
                cart = session.Get<List<CartItem>>("CartItems") as List<CartItem>;
            }
            return cart;
        }

        public static void AddCartItemToSession(this PlaceAnOrderContex.ICartItem cartItem, ISessionManager session)
        {
            if (cartItem is CartItem item && session is SessionManager sessionManager)
            {
                List<CartItem> cart = session.GetCart();
                CartItem cartItemSession = cart.Find(c => c.Product.ProductId == item.Product.ProductId);

                if (cartItemSession != null)
                {
                    cartItemSession.Quantity = item.Quantity;
                    cartItemSession.TotalPrice = cartItemSession.Quantity * cartItemSession.Product.Price;
                }
                else cart.Add(item);
                sessionManager.Set("CartItems", cart);
            }
        }

        public static void RemoveCartItemFromSession(this PlaceAnOrderContex.ICartItem cartItem, ISessionManager session)
        {
            if (cartItem is CartItem item && session is SessionManager sessionManager)
            {
                List<CartItem> cart = session.GetCart();
                CartItem cartItemSession = cart.Find(c => c.Product.ProductId == item.Product.ProductId);
                if (cartItemSession != null)
                {
                    cart.Remove(cartItemSession);
                }
            }
        }

        public static CartItem FindItemCart(this PlaceAnOrderContex.ICartItem cartItem, ISessionManager session)
        {
            if (cartItem is CartItem item)
            {
                List<CartItem> cart = session.GetCart();
                if (cart.Count == 0)
                {
                    return null;
                }
                else
                {
                    return cart.Find(c => c.Product.ProductId == item.Product.ProductId);
                }
            }
            else return null;
        }

        public static bool SaveOrder(this PlaceAnOrderContex.IOrder orderPlaced, ISessionManager session, DB_Entities _db)
        {
            List<CartItem> cart = session.GetCart();
            if (orderPlaced is Order order)
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
                    order.TotalPrice += (item.Quantity * item.Product.Price);
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