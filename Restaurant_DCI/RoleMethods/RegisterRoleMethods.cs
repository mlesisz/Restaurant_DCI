using Restaurant_DCI.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Restaurant_DCI.Contex;

namespace Restaurant_DCI.RoleMethods
{
    public static class RegisterRoleMethods
    {
        public static bool Register(this RegisterContex.IUser user, DB_Entities _db)
        {
            Account _user = user as Account;
            if (_user != null)
            {
                var check = _db.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    _user.Password = GetMD5(_user.Password);
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _db.Users.Add(_user);
                    _db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
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