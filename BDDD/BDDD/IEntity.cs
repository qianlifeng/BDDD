using System;

namespace BDDD
{
    /// <summary>
    ///     实现这个接口的类表明为实体
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        ///     实体标志
        /// </summary>
        Guid ID { get; set; }
    }
}