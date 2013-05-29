using System;

namespace BDDD.Interception
{
    /// <summary>
    ///     Represents that the decorated classes are requiring a base type
    ///     when its interface is proxied by the Castle dynamic proxy mechanism.
    /// </summary>
    /// <remarks>
    ///     By using this attribute on the class, when the Castle Dynamic
    ///     Proxy framework is creating the proxy class for this class' interface,
    ///     the base type specified in this attribute will be used as the base type
    ///     for the created proxy class.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class BaseTypeForInterfaceProxyAttribute : Attribute
    {
        public BaseTypeForInterfaceProxyAttribute(Type baseType)
        {
            BaseType = baseType;
        }

        /// <summary>
        ///     Gets or sets the base type from which the generated proxy object
        ///     should derive.
        /// </summary>
        public Type BaseType { get; set; }
    }
}