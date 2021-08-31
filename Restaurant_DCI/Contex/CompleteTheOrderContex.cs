using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant_DCI.Models;
using Restaurant_DCI.RoleMethods;

namespace Restaurant_DCI.Contex
{
    public class CompleteTheOrderContex
    {
        #region Roles and RolesInterfaces
        public interface IOrderItem { }
        public IOrderItem OrderItem { get; set; }
        #endregion
        public DB_Entities Db { get; private set; }
        public CompleteTheOrderContex(IOrderItem orderItem, DB_Entities _db)
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