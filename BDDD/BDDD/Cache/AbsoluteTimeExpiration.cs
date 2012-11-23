using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Cache
{
    /// <summary>
    /// 绝对时间过期策略，即从缓存项加入开始，达到固定时间后过期
    /// </summary>
    public class AbsoluteTimeExpiration : ICacheExpiration
    {
        private DateTime startTime;
        private DateTime expirationTime;

        public AbsoluteTimeExpiration(TimeSpan timespan)
        {
            startTime = DateTime.Now;
            expirationTime = startTime.Add(timespan);
        }

        public bool HasExpirationed()
        {
            return DateTime.Now > expirationTime;
        }
    }
}
