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
        public ISessionManager SessionManager { get; private set; }
        public PlaceAnOrderContex(IPlaceAnOrderCartItem placeAnOrderCartItem,ISessionManager sessionManager)
        {
            CartItem = placeAnOrderCartItem;
            SessionManager = sessionManager;
        }
        public void AddCartItemToSession()
        {
            CartItem.AddCartItemToSession(SessionManager);
        }
        public CartItem FindCartItemInSession()
        {
            return CartItem.FindItemCart(SessionManager);
        }
    }
}