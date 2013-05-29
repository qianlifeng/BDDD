using System;

namespace BDDD.Cache.Memcached
{
    public class MemcachedAbsoluteTimeExpiration : AbsoluteTimeExpiration
    {
        public MemcachedAbsoluteTimeExpiration(TimeSpan timeSpan)
            : base(timeSpan)
        {
        }

        protected override T DoGetExpirationStrategy<T>()
        {
            if (!typeof (T).Equals(typeof (AbsoluteTimeExpiration)))
                throw new CacheException("类型 {0} 不对， 必须是 {1}",
                                         typeof (T).AssemblyQualifiedName,
                                         typeof (AbsoluteTimeExpiration).AssemblyQualifiedName);

            return this as T;
        }
    }
}