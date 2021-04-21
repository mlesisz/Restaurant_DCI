using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant_DCI.Models;

namespace Restaurant_DCI.Roles
{
    public interface ISessionManager
    {
        void Abandon();
        T Get<T>(string key);
        T Get<T>(string key, Func<T> createDefault);
        void Set<T>(string name, T value);
    }
}
