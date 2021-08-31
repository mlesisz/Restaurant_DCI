using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant_DCI.RoleMethods;
using Restaurant_DCI.Models;

namespace Restaurant_DCI.Contex
{
    public class BrowsingOrdersContex 
    {
        #region Roles and RolesInterfaces
        public interface IOrder { }
        public IOrder Order { get; set; }
        public interface IChef { }
        public IChef Chef { get; set; }
        public interface IClient { }
        public IClient Client { get; set; }
        public DB_Entities Db { get; private set; }
        #endregion

        public BrowsingOrdersContex(IOrder order, Account account,DB_Entities _db)
        {
            Order = order;
            if(account.Permissions == Permissions.User)
            {
                Client = account;
            }else if(account.Permissions == Permissions.Chef)
            {
                Chef = account;
            }
            Db = _db;
        }
        public BrowsingOrdersContex(IOrder order, DB_Entities _db)
        {
            Order = order;
            Db = _db;
        }

        public Order FindOrder ()
        {
            return Order.FindOrder(Db);
        }
        public List<Order> FindOrders()
        {
            return Order.FindOrders(Chef, Client, Db);
        }
    }
}