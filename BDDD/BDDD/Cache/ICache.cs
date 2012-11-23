using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Cache
{
    public interface ICache
    {
        T GetCache<T>(string key);

        void AddCache(string key, object obj, ICacheExpiration expiration);

        void RemoveCache(string key);
    }
}
