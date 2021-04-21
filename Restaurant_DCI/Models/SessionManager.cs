﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Restaurant_DCI.Roles;

namespace Restaurant_DCI.Models
{
    public class SessionManager : ISessionManager
    {
        private readonly HttpSessionState _session;

        public SessionManager()
        {
            _session = HttpContext.Current.Session;
        }
        public void Set<T>(string name, T value)
        {
            _session[name] = value;
        }
        public T Get<T>(string key)
        {
            return (T)_session[key];
        }
        public T Get<T>(string key, Func<T> createDefault)
        {
            T retval;

            if (_session[key] != null && _session[key].GetType() == typeof(T))
            {
                retval = (T)_session[key];
            }
            else
            {
                retval = createDefault();
                _session[key] = retval;
            }

            return retval;
        }

        public void Abandon()
        {
            _session.Abandon();
        }
    }
}