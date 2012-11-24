using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Cache
{
    /// <summary>
    /// 绝对时间过期策略，即从缓存项加入开始，达到固定时间后过期
    /// </summary>
    public abstract class AbsoluteTimeExpiration : ICacheExpiration
    {
        protected TimeSpan expirationTime;

        protected abstract T DoGetExpirationStrategy<T>() where T : class;

        public AbsoluteTimeExpiration(TimeSpan timespan)
        {
            expirationTime = timespan;
        }

        public T GetExpirationStrategy<T>() where T:class
        {
            return DoGetExpirationStrategy<T>();
        }
    }
}
