using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using BDDD.Config;
using BDDD.Application;
using System.Reflection;

namespace BDDD.Interception
{
    /// <summary>
    /// 拦截选择器，从配置中决定那些类型需要被拦截
    /// </summary>
    public class InterceptorSelector : IInterceptorSelector
    {

        private MethodInfo GetMethodInBase(Type baseType, MethodInfo thisMethod)
        {
            MethodInfo[] methods = baseType.GetMethods();
            var methodQuery = methods.Where(p =>
            {
                var retval = p.Name == thisMethod.Name &&
                p.IsGenericMethod == thisMethod.IsGenericMethod &&
                ((p.GetParameters() == null && thisMethod.GetParameters() == null) || (p.GetParameters().Length == thisMethod.GetParameters().Length));
                if (!retval)
                    return false;
                var thisMethodParameters = thisMethod.GetParameters();
                var pMethodParameters = p.GetParameters();
                for (int i = 0; i < thisMethodParameters.Length; i++)
                {
                    retval &= pMethodParameters[i].ParameterType == thisMethodParameters[i].ParameterType;
                }
                return retval;
            });
            if (methodQuery != null && methodQuery.Count() > 0)
                return methodQuery.Single();
            return null;
        }

        #region IInterceptorSelector接口

        public IInterceptor[] SelectInterceptors(Type type, System.Reflection.MethodInfo method, IInterceptor[] interceptors)
        {
            IConfigSource configSource = AppRuntime.Instance.CurrentApplication.ConfigSource;
            List<IInterceptor> selectedInterceptors = new List<IInterceptor>();

            IEnumerable<string> interceptorTypes = configSource.Config.GetInterceptorTypes(type, method);
            if (interceptorTypes == null)
            {
                if (type.BaseType != null && type.BaseType != typeof(Object))
                {
                    Type baseType = type.BaseType;
                    MethodInfo methodInfoBase = null;
                    while (baseType != null && type.BaseType != typeof(Object))
                    {
                        methodInfoBase = GetMethodInBase(baseType, method);
                        if (methodInfoBase != null)
                            break;
                        baseType = baseType.BaseType;
                    }
                    if (baseType != null && methodInfoBase != null)
                    {
                        interceptorTypes = configSource.Config.GetInterceptorTypes(baseType, methodInfoBase);
                    }
                }
                if (interceptorTypes == null)
                {
                    var intfTypes = type.GetInterfaces();
                    if (intfTypes != null && intfTypes.Count() > 0)
                    {
                        foreach (var intfType in intfTypes)
                        {
                            var methodInfoBase = GetMethodInBase(intfType, method);
                            if (methodInfoBase != null)
                                interceptorTypes = configSource.Config.GetInterceptorTypes(intfType, methodInfoBase);
                            if (interceptorTypes != null)
                                break;
                        }
                    }
                }
            }

            if (interceptorTypes != null && interceptorTypes.Count() > 0)
            {
                foreach (var interceptor in interceptors)
                {
                    if (interceptorTypes.Any(p => interceptor.GetType().AssemblyQualifiedName.Equals(p)))
                        selectedInterceptors.Add(interceptor);
                }
            }

            return selectedInterceptors.ToArray();
        }

        #endregion
    }
}
