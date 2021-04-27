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
                List<CartItem> cart = session.GetCart();
                CartItem cartItemSession = cart.Find(c=>c.Product.ProductId==item.Product.ProductId);

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
        public static void RemoveCartItemFromSession(this IPlaceAnOrderCartItem cartItem, ISessionManager session)
        {
            if (cartItem is CartItem item && session is SessionManager sessionManager)
            {
                List<CartItem> cart = session.GetCart();
                CartItem cartItemSession = cart.Find(c => c.Product.ProductId == item.Product.ProductId);
                if(cartItemSession != null)
                {
                    cart.Remove(cartItemSession);
                }
            }

        }
        public static CartItem FindItemCart(this IPlaceAnOrderCartItem cartItem, ISessionManager session)
        {
            if(cartItem is CartItem item)
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
            else
            {
                return null;
            }
        }
    }
}
