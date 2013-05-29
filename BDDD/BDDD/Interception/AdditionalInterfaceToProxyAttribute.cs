using System;

namespace BDDD.Interception
{
    /// <summary>
    ///     标志此Attribute的类表明需要额外的接口需要被拦截
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class AdditionalInterfaceToProxyAttribute : Attribute
    {
        public AdditionalInterfaceToProxyAttribute(Type intfType)
        {
            InterfaceType = intfType;
        }

        /// <summary>
        ///     代理创建的时候需要被拦截的接口
        /// </summary>
        public Type InterfaceType { get; set; }
    }
}