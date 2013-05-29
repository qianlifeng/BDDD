using System;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

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
            if (!typeof (T).Equals(typeof (ICacheItemExpiration)))
                throw new CacheException("类型 {0} 不对， 必须是 {1}",
                                         typeof (T).AssemblyQualifiedName,
                                         typeof (ICacheItemExpiration).AssemblyQualifiedName);

            var slidingTime = new SlidingTime(ExpirationTime);
            return slidingTime as T;
        }
    }
}