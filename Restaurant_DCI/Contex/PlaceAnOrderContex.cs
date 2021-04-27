using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant_DCI.Roles;
using Restaurant_DCI.Models;

namespace Restaurant_DCI.Contex
{
    public class PlaceAnOrderContex
    {
        public IPlaceAnOrderCartItem CartItem { get; private set; }
        public ISessionManager Session { get; private set; }
        public IPlaceAnOrderOrderPlaced OrderPlaced { get; set; }
        public DB_Entities Db { get; private set; }
        public PlaceAnOrderContex(IPlaceAnOrderCartItem placeAnOrderCartItem,ISessionManager sessionManager)
        {
            CartItem = placeAnOrderCartItem;
            Session = sessionManager;
        }
        public PlaceAnOrderContex(IPlaceAnOrderOrderPlaced orderPlaced, ISessionManager sessionManager, DB_Entities _db)
        {
            OrderPlaced = orderPlaced;
            Session = sessionManager;
            Db = _db;
        }
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
        public List<CartItem> GetCarts()
        {
            return Session.GetCart();
        }
        public bool SaveOrder()
        {
            return OrderPlaced.SaveOrder(Session,Db);
        }
    }
}