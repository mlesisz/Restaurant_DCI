using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant_DCI.Models;

namespace Restaurant_DCI.Roles
{
    public interface ISessionManager
    {
        void Abandon();
        T Get<T>(string key);
        T Get<T>(string key, Func<T> createDefault);
        void Set<T>(string name, T value);
    }

    public static class PlaceAnOrderSessionManagerTraits
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
    }
}
