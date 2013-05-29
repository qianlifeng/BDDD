using Enyim.Caching;
using Enyim.Caching.Memcached;

namespace BDDD.Cache.Memcached
{
    /// <summary>
    ///     基于Memcached的缓存类
    ///     使用方法：http://blog.csdn.net/dinglang_2009/article/details/6917794
    /// </summary>
    public class MemcachedCache : Cache
    {
        private readonly MemcachedClient client = new MemcachedClient("memcached");

        protected override T DoGetCache<T>(string key)
        {
            return client.Get<T>(key);
        }

        protected override void DoAddCache(string key, object obj, ICacheExpiration expiration)
        {
            bool isSuccess = client.Store(StoreMode.Add, key, obj,
                                          expiration.GetExpirationStrategy<AbsoluteTimeExpiration>().ExpirationTime);
            if (!isSuccess)
            {
                throw new CacheException("添加失败");
            }
        }

        protected override void DoRemoveCache(string key)
        {
            client.Remove(key);
        }
    }
}