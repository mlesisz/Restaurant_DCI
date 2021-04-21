using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant_DCI.Models;

namespace Restaurant_DCI.Roles
{
    public interface IPlaceAnOrderCartItem
    {
    }

    public static class PlaceAnOrderCartItemTraits
    {
        public static void AddCartItemToSession(this IPlaceAnOrderCartItem cartItem, ISessionManager session)
        {
            if(cartItem is CartItem item && session is SessionManager sessionManager)
            {
                List<CartItem> cart = GetCart(sessionManager);
                CartItem cartItemSession = cart.Find(c=>c.Product.IdProduct==item.Product.IdProduct);

                if (cartItemSession != null)
                {
                    cartItemSession.Quantity = item.Quantity;
                    cartItemSession.TotalPrice = cartItemSession.Quantity * cartItemSession.Product.Price;
                }
                else
                {
                    cart.Add(item);
                }
                sessionManager.Set("CartItems",cart);
            }
        }
        public static CartItem FindItemCart(this IPlaceAnOrderCartItem cartItem, ISessionManager session)
        {
            if(cartItem is CartItem item)
            {
                List<CartItem> cart = GetCart(session);
                if (cart.Count == 0)
                {
                    return null;
                }
                else
                {
                    return cart.Find(c => c.Product.IdProduct == item.Product.IdProduct);
                }
            }
            else
            {
                return null;
            }
        }
        public static List<CartItem> GetCart(ISessionManager session)
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
    }
}
