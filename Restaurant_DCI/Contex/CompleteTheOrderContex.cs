using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant_DCI.Models;
using Restaurant_DCI.Roles;

namespace Restaurant_DCI.Contex
{
    public class CompleteTheOrderContex
    {
        public ICompleteTheOrderOrderItem OrderItem { get; set; }
        public DB_Entities Db { get; private set; }
        public CompleteTheOrderContex(ICompleteTheOrderOrderItem orderItem, DB_Entities _db)
        {
            OrderItem = orderItem;
            Db = _db;
        }
        public void MakeOrderItem()
        {
            OrderItem.Make(Db);
        }
    }
}