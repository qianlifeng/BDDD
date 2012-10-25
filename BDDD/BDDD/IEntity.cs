using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD
{
    /// <summary>
    /// 实现这个接口的类表明为实体
    /// </summary>
    public interface IEntity : IEquatable<IEntity>
    {
        /// <summary>
        /// 实体标志
        /// </summary>
        Guid ID { get; set; }
    }
}
