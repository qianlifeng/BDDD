using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDD.ObjectContainer;

namespace BDDD.Cache
{
    /// <summary>
    /// 缓存管理类
    /// </summary>
    public class CacheManager
    {
        private ICache cache;
        private static readonly CacheManager cacheManager = new CacheManager();

        private CacheManager()
        {
            cache = ServiceLocator.Instance.GetService<ICache>();
        }

        /// <summary>
        /// 从当前缓存容器中获得缓存
        /// </summary>
        /// <typeparam name="T">缓存的类型</typeparam>
        /// <param name="key">键</param>
        /// <returns>缓存的内容</returns>
        public static T GetCache<T>(string key)
        {
            return cacheManager.cache.GetCache<T>(key);
        }

        /// <summary>
        /// 向当前缓存器中增加项
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="obj">值</param>
        /// <param name="expiration">过期策略</param>
        public static void AddCache(string key, object obj, ICacheExpiration expiration)
        {
            cacheManager.cache.AddCache(key, obj, expiration);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">键</param>
        public static void RemoveCache(string key)
        {
            cacheManager.cache.RemoveCache(key);
        }
    }
}
