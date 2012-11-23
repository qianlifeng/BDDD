using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Cache
{
    public abstract class Cache : ICache
    {
        protected abstract T DoGetCache<T>(string key);
        protected abstract void DoAddCache(string key, object obj, ICacheExpiration expiration);
        protected abstract void DoRemoveCache(string key);

        public T GetCache<T>(string key)
        {
            return DoGetCache<T>(key);
        }

        public void AddCache(string key, object obj, ICacheExpiration expiration)
        {
            DoAddCache(key, obj, expiration);
        }

        public void RemoveCache(string key)
        {
            DoRemoveCache(key);
        }
    }
}
