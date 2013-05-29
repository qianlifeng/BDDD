using System;
using System.Collections.Generic;
using System.Linq;
using BDDD.Application;
using BDDD.Interception;
using Castle.DynamicProxy;

namespace BDDD.ObjectContainer
{
    public abstract class ObjectContainer : IObjectContainer
    {
        #region 变量

        private readonly IInterceptorSelector interceptorSelector = new InterceptorSelector();
        private readonly ProxyGenerationOptions proxyGenerationOptions;
        private readonly ProxyGenerator proxyGenerator = new ProxyGenerator();

        #endregion

        public ObjectContainer()
        {
            proxyGenerationOptions = new ProxyGenerationOptions {Selector = interceptorSelector};
        }

        /// <summary>
        ///     利用从Ioc容器中获得对象的契机来进行对象的替换
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="targetObject"></param>
        /// <returns></returns>
        private object GetProxyObject(Type targetType, object targetObject)
        {
            IInterceptor[] interceptors = AppRuntime.Instance.CurrentApplication.Interceptors.ToArray();

            if (interceptors == null || interceptors.Length == 0)
                return targetObject;

            if (targetType.IsInterface)
            {
                object obj = null;
                var proxyGenerationOptionsForInterface = new ProxyGenerationOptions();
                proxyGenerationOptionsForInterface.Selector = interceptorSelector;
                Type targetObjectType = targetObject.GetType();
                if (targetObjectType.IsDefined(typeof (BaseTypeForInterfaceProxyAttribute), false))
                {
                    var baseTypeForIPAttribute =
                        targetObjectType.GetCustomAttributes(typeof (BaseTypeForInterfaceProxyAttribute), false)[0] as
                        BaseTypeForInterfaceProxyAttribute;
                    proxyGenerationOptionsForInterface.BaseTypeForInterfaceProxy = baseTypeForIPAttribute.BaseType;
                }
                if (targetObjectType.IsDefined(typeof (AdditionalInterfaceToProxyAttribute), false))
                {
                    List<Type> intfTypes =
                        targetObjectType.GetCustomAttributes(typeof (AdditionalInterfaceToProxyAttribute), false)
                                        .Select(p =>
                                            {
                                                var attrib = p as AdditionalInterfaceToProxyAttribute;
                                                return attrib.InterfaceType;
                                            }).ToList();
                    obj = proxyGenerator.CreateInterfaceProxyWithTarget(targetType, intfTypes.ToArray(), targetObject,
                                                                        proxyGenerationOptionsForInterface, interceptors);
                }
                else
                    obj = proxyGenerator.CreateInterfaceProxyWithTarget(targetType, targetObject,
                                                                        proxyGenerationOptionsForInterface, interceptors);
                return obj;
            }
            else
                return proxyGenerator.CreateClassProxyWithTarget(targetType, targetObject, proxyGenerationOptions,
                                                                 interceptors);
        }

        protected abstract T DoGetService<T>() where T : class;
        protected abstract T DoGetService<T>(string name) where T : class;
        protected abstract object DoGetService(Type serviceType);
        protected abstract T DoGetRealObjectContainer<T>() where T : class;
        protected abstract void DoInitializeFromConfigFile(string configSectionName);

        #region IObjectContainer接口

        public T GetService<T>() where T : class
        {
            var serviceImpl = DoGetService<T>();
            return GetProxyObject(typeof (T), serviceImpl) as T;
        }

        public T GetService<T>(string name) where T : class
        {
            var serviceImpl = DoGetService<T>(name);
            return GetProxyObject(typeof (T), serviceImpl) as T;
        }

        public object GetService(Type serviceType)
        {
            object serviceImpl = DoGetService(serviceType);
            return GetProxyObject(serviceType, serviceImpl);
        }

        public T GetRealObjectContainer<T>() where T : class
        {
            //todo:当ManualConfigSource中添加了interceptor后，这里返回的ObjectContainer
            //每次都不一样，暂时找不到原因，临时解决是对于objectContainer
            //不添加拦截方法，ObjectContainer只是用于注册关系，一般不需要拦截
            var serviceImpl = DoGetRealObjectContainer<T>();
            //return GetProxyObject(typeof(T), serviceImpl) as T;
            return serviceImpl;
        }

        public void InitializeFromConfigFile(string configSectionName)
        {
            DoInitializeFromConfigFile(configSectionName);
        }

        #endregion
    }
}