﻿using Restaurant_DCI.Models;
using Restaurant_DCI.RoleMethods;

namespace Restaurant_DCI.Contex
{
    public class RegisterContex
    {
        #region Roles and RolesInterfaces
        public interface IUser { }
        public IUser User { get; private set; }
        #endregion

        public DB_Entities Db { get; private set; }
        public RegisterContex(IUser user, DB_Entities _db)
        {
            User = user;
            Db = _db;
        }
        public bool SuccessfulRegiser()
        {
            return User.Register(Db);
        }
    }
}