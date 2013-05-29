using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BDDD.Application;
using BDDD.Config;
using Castle.DynamicProxy;

namespace BDDD.Interception
{
    /// <summary>
    ///     拦截选择器，从配置中决定那些类型需要被拦截
    /// </summary>
    public class InterceptorSelector : IInterceptorSelector
    {
        /// <summary>
        /// </summary>
        /// <param name="type">已经经过透明代理的类型（此处的参数是真实类型）</param>
        /// <param name="method">透明代理调用的方法</param>
        /// <param name="interceptors">可用的拦截器</param>
        /// <returns></returns>
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            IConfigSource configSource = AppRuntime.Instance.CurrentApplication.ConfigSource;
            var selectedInterceptors = new List<IInterceptor>();

            //从配置中查找所有需要对该类型的该方法进行拦截的所有拦截器
            IEnumerable<string> interceptorTypes = configSource.Config.GetInterceptorTypes(type, method);
            if (interceptorTypes == null)
            {
                if (type.BaseType != null && type.BaseType != typeof (Object))
                {
                    Type baseType = type.BaseType;
                    MethodInfo methodInfoBase = null;
                    while (baseType != null && type.BaseType != typeof (Object))
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
                    Type[] intfTypes = type.GetInterfaces();
                    if (intfTypes != null && intfTypes.Count() > 0)
                    {
                        foreach (Type intfType in intfTypes)
                        {
                            MethodInfo methodInfoBase = GetMethodInBase(intfType, method);
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
                //从所有拦截器中过滤匹配找到的拦截器
                foreach (IInterceptor interceptor in interceptors)
                {
                    if (interceptorTypes.Any(p => interceptor.GetType().AssemblyQualifiedName.Equals(p)))
                        selectedInterceptors.Add(interceptor);
                }
            }

            return selectedInterceptors.ToArray();
        }

        private MethodInfo GetMethodInBase(Type baseType, MethodInfo thisMethod)
        {
            MethodInfo[] methods = baseType.GetMethods();
            IEnumerable<MethodInfo> methodQuery = methods.Where(p =>
                {
                    bool retval = p.Name == thisMethod.Name &&
                                  p.IsGenericMethod == thisMethod.IsGenericMethod &&
                                  ((p.GetParameters() == null && thisMethod.GetParameters() == null) ||
                                   (p.GetParameters().Length == thisMethod.GetParameters().Length));
                    if (!retval)
                        return false;
                    ParameterInfo[] thisMethodParameters = thisMethod.GetParameters();
                    ParameterInfo[] pMethodParameters = p.GetParameters();
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
    }
}