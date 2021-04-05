using Restaurant_DCI.Models;
using Restaurant_DCI.Roles;

namespace Restaurant_DCI.Contex
{
    public class LoginContex
    {
        public ILoginUser User { get; private set; }
        public DB_Entities Db { get; private set; }
        public LoginContex(LoginViewModel user, DB_Entities _db)
        {
            User = user;
            Db = _db;
        }
        public bool SuccessfulLogin()
        {
            return User.Login(Db);
        }

    }
}