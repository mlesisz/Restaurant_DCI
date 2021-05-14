using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant_DCI.Roles;
using Restaurant_DCI.Models;

namespace Restaurant_DCI.Contex
{
    public class BrowsingOrdersContex 
    {
        public IBrowsingOrdersOrder Order { get; set; }
        public IBrowsingOrdersChef Chef { get; set; }
        public IBrowsingOrdersClient Client { get; set; }
        public DB_Entities Db { get; private set; }

        public BrowsingOrdersContex(IBrowsingOrdersOrder order, Account account,DB_Entities _db)
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
        public BrowsingOrdersContex(IBrowsingOrdersOrder order, DB_Entities _db)
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
            return Order.FindOrders(Chef,Client,Db);
        }
    }
}