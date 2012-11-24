using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Microsoft.Practices.EnterpriseLibrary.Caching;

namespace BDDD.Cache.MSEnterpriseLibrary
{
    public class MSELAbsoluteTimeExpiration : AbsoluteTimeExpiration
    {
        public MSELAbsoluteTimeExpiration(TimeSpan timeSpan)
            : base(timeSpan)
        {

        }

        protected override T DoGetExpirationStrategy<T>()
        {
            if (!typeof(T).Equals(typeof(ICacheItemExpiration)))
                throw new CacheException("类型 {0} 不对， 必须是 {1}",
                    typeof(T).AssemblyQualifiedName,
                    typeof(ICacheItemExpiration).AssemblyQualifiedName);

            SlidingTime slidingTime = new SlidingTime(expirationTime);
            return slidingTime as T;
        }
    }
}
