using System;

namespace Restaurant_DCI.RoleMethods
{
    public interface ISessionManager
    {
        void Abandon();
        T Get<T>(string key);
        T Get<T>(string key, Func<T> createDefault);
        void Set<T>(string name, T value);
    }
}
