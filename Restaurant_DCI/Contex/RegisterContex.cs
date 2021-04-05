using Restaurant_DCI.Models;
using Restaurant_DCI.Roles;

namespace Restaurant_DCI.Contex
{
    public class RegisterContex
    {
        public IRegisterUser User { get; private set; }
        public DB_Entities Db { get; private set; }
        public RegisterContex(Account user, DB_Entities _db)
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