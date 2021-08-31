using System.Collections.Generic;
using Restaurant_DCI.RoleMethods;
using Restaurant_DCI.Models;

namespace Restaurant_DCI.Contex
{
    public class PlaceAnOrderContex
    {
        #region Roles and RolesInterfaces
        public interface ICartItem{ }
        internal ICartItem CartItem { get; private set; }
        public interface IOrder { }
        public IOrder Order { get; set; }
        #endregion

        public ISessionManager Session { get; private set; }
        
        public DB_Entities Db { get; private set; }
        public PlaceAnOrderContex(ICartItem cartItem,ISessionManager sessionManager)
        {
            CartItem = cartItem;
            Session = sessionManager;
        }
        public PlaceAnOrderContex(IOrder orderPlaced, ISessionManager sessionManager, DB_Entities _db)
        {
            Order = orderPlaced;
            Session = sessionManager;
            Db = _db;
        }

        #region Interactions
        public void AddCartItemToSession()
        {
            CartItem.AddCartItemToSession(Session);
        }
        public CartItem FindCartItemInSession()
        {
            return CartItem.FindItemCart(Session);
        }
        public void RemoveCartItemFromSession()
        {
            CartItem.RemoveCartItemFromSession(Session);
        }
        public List<CartItem> GetCart()
        {
            return Session.GetCart();
        }
        public bool SaveOrder()
        {
            return Order.SaveOrder(Session,Db);
        }
        #endregion
    }
}