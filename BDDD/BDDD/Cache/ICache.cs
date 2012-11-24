using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Cache
{
    /// <summary>
    /// 实现此接口的类具有操作缓存的能力
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// 获得缓存
        /// </summary>
        /// <typeparam name="T">值类型</typeparam>
        /// <param name="key">键</param>
        /// <returns></returns>
        T GetCache<T>(string key);

        /// <summary>
        /// 向当前缓存器中增加项
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="obj">值</param>
        /// <param name="expiration">过期策略</param>
        void AddCache(string key, object obj, ICacheExpiration expiration);

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">键</param>
        void RemoveCache(string key);
    }
}
