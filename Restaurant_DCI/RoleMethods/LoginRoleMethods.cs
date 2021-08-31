using Restaurant_DCI.Models;
using Restaurant_DCI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Restaurant_DCI.Contex;

namespace Restaurant_DCI.RoleMethods
{

    public static class LoginRoleMethods
    {
        public static bool Login(this LoginContex.IUser loginData, DB_Entities _db)
        {
            if(loginData is Account _loginData)
            {
                _loginData.Password = GetMD5(_loginData.Password);
                Account user = _db.Users.FirstOrDefault(s => s.Email.Equals(_loginData.Email) && s.Password.Equals(_loginData.Password));
                if (user != null)
                {
                    HttpContext context = HttpContext.Current;
                    context.Session["idUser"] = user.idUser;
                    context.Session["Permissions"] = user.Permissions;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}
