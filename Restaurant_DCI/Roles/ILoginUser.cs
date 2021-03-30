using Restaurant_DCI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Restaurant_DCI.Roles
{
    public interface ILoginUser
    {
    }

    public static class LoginUserTraits
    {
        public static HttpContext Login(this ILoginUser user, DB_Entities _db)
        {
            if(user is Account _user)
            {
                _user.Password = GetMD5(_user.Password);
                _user = _db.Users.FirstOrDefault(s => s.Email.Equals(_user.Email) && s.Password.Equals(_user.Password));
                //var data = _db.Users.Where(s => s.Email.Equals(_user.Email) && s.Password.Equals(_user.Password)).ToList();
                if (_user != null)
                {
                    HttpContext context = HttpContext.Current;
                    context.Session["FullName"] = _user.FirstName + " " + _user.LastName;
                    context.Session["Email"] = _user.Email;
                    context.Session["idUser"] = _user.idUser;
                    return context;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
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
