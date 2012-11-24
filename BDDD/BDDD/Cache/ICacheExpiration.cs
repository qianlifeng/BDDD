using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Cache
{
    /// <summary>
    /// 实现此接口的类表示了不同的缓存过期策略
    /// </summary>
    public interface ICacheExpiration
    {
        T GetExpirationStrategy<T>() where T : class;
    }
}
