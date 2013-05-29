using Microsoft.Practices.EnterpriseLibrary.Caching;

namespace BDDD.Cache.MSEnterpriseLibrary
{
    public class MSELCache : ICache
    {
        private readonly ICacheManager manager = CacheFactory.GetCacheManager();

        public T GetCache<T>(string key)
        {
            return (T) manager.GetData(key);
        }

        public void AddCache(string key, object obj, ICacheExpiration expiration)
        {
            manager.Add(key, obj, CacheItemPriority.Normal, null,
                        expiration.GetExpirationStrategy<ICacheItemExpiration>());
        }

        public void RemoveCache(string key)
        {
            manager.Remove(key);
        }
    }
}