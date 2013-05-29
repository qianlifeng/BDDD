using System;
using System.Reflection;
using Castle.DynamicProxy;

namespace BDDD.Config
{
    /// <summary>
    ///     允许以编程的方式设置和框架读取配置信息
    /// </summary>
    public class ManualConfigSource : IConfigSource
    {
        private readonly BDDDConfigSection config;

        public ManualConfigSource()
        {
            config = new BDDDConfigSection();
            config.Interception = new InterceptionElement();
            config.Interception.Interceptors = new InterceptorElementCollection();
        }

        public Type ObjectContainer
        {
            get { return Type.GetType(config.ObjectContainer.Provider); }
            set { config.ObjectContainer.Provider = value.AssemblyQualifiedName; }
        }

        public BDDDConfigSection Config
        {
            get { return config; }
        }

        /// <summary>
        ///     向配置信息中添加一个拦截器
        /// </summary>
        /// <param name="name">拦截器的名字</param>
        /// <param name="interceptorType">拦截器类型</param>
        public void AddInterceptor(string name, Type interceptorType)
        {
            if (!typeof (IInterceptor).IsAssignableFrom(interceptorType))
                throw new ConfigException("'{0}' 不是一个可用的拦截类型，拦截器必须继承 IInterceptor 接口", interceptorType);

            if (config.Interception == null)
                config.Interception = new InterceptionElement();
            if (config.Interception.Interceptors == null)
                config.Interception.Interceptors = new InterceptorElementCollection();
            //如果已经存在相同名字或者类型的拦截器，则直接返回
            foreach (InterceptorElement interceptor in config.Interception.Interceptors)
            {
                if (interceptor.Name.Equals(name) || interceptor.Type.Equals(interceptorType.AssemblyQualifiedName))
                    return;
            }
            var interceptorAdd = new InterceptorElement();
            interceptorAdd.Name = name;
            interceptorAdd.Type = interceptorType.AssemblyQualifiedName;
            config.Interception.Interceptors.Add(interceptorAdd);
        }

        /// <summary>
        ///     向配置信息中添加一个拦截器
        /// </summary>
        /// <param name="interceptorType">拦截器类型</param>
        public void AddInterceptor(Type interceptorType)
        {
            AddInterceptor(interceptorType.AssemblyQualifiedName, interceptorType);
        }

        /// <summary>
        ///     为制定类型的指定方法添加拦截器
        /// </summary>
        /// <param name="contractType">需要拦截方法的类型</param>
        /// <param name="method">需要拦截的方法</param>
        /// <param name="name">拦截器的名字</param>
        public void AddInterceptorRef(Type contractType, MethodInfo method, string name)
        {
            if (config.Interception != null)
            {
                if (config.Interception.Contracts != null)
                {
                    foreach (InterceptContractElement interceptContract in config.Interception.Contracts)
                    {
                        if (interceptContract.Type.Equals(contractType.AssemblyQualifiedName))
                        {
                            if (interceptContract.Methods != null)
                            {
                                foreach (InterceptMethodElement interceptMethod in interceptContract.Methods)
                                {
                                    if (interceptMethod.Signature.Equals(method.GetSignature()))
                                    {
                                        if (interceptMethod.InterceptorRefs != null)
                                        {
                                            foreach (
                                                InterceptorRefElement interceptorRef in interceptMethod.InterceptorRefs)
                                            {
                                                if (interceptorRef.Name.Equals(name))
                                                    return;
                                            }
                                            interceptMethod.InterceptorRefs.Add(new InterceptorRefElement {Name = name});
                                        }
                                        else
                                        {
                                            interceptMethod.InterceptorRefs = new InterceptorRefElementCollection();
                                            interceptMethod.InterceptorRefs.Add(new InterceptorRefElement {Name = name});
                                        }
                                        return;
                                    }
                                }
                                var interceptMethodAdd = new InterceptMethodElement();
                                interceptMethodAdd.Signature = method.GetSignature();
                                interceptMethodAdd.InterceptorRefs = new InterceptorRefElementCollection();
                                interceptMethodAdd.InterceptorRefs.Add(new InterceptorRefElement {Name = name});
                                interceptContract.Methods.Add(interceptMethodAdd);
                            }
                            else
                            {
                                interceptContract.Methods = new InterceptMethodElementCollection();
                                var interceptMethodAdd = new InterceptMethodElement();
                                interceptMethodAdd.Signature = method.GetSignature();
                                interceptMethodAdd.InterceptorRefs = new InterceptorRefElementCollection();
                                interceptMethodAdd.InterceptorRefs.Add(new InterceptorRefElement {Name = name});
                                interceptContract.Methods.Add(interceptMethodAdd);
                            }
                            return;
                        }
                    }
                    var interceptContractAdd = new InterceptContractElement();
                    interceptContractAdd.Type = contractType.AssemblyQualifiedName;
                    interceptContractAdd.Methods = new InterceptMethodElementCollection();
                    var interceptMethodAddToContract = new InterceptMethodElement();
                    interceptMethodAddToContract.Signature = method.GetSignature();
                    interceptMethodAddToContract.InterceptorRefs = new InterceptorRefElementCollection();
                    interceptMethodAddToContract.InterceptorRefs.Add(new InterceptorRefElement {Name = name});
                    interceptContractAdd.Methods.Add(interceptMethodAddToContract);
                    config.Interception.Contracts.Add(interceptContractAdd);
                }
                else
                {
                    config.Interception.Contracts = new InterceptContractElementCollection();
                    var interceptContractAdd = new InterceptContractElement();
                    interceptContractAdd.Type = contractType.AssemblyQualifiedName;
                    interceptContractAdd.Methods = new InterceptMethodElementCollection();
                    var interceptMethodAddToContract = new InterceptMethodElement();
                    interceptMethodAddToContract.Signature = method.GetSignature();
                    interceptMethodAddToContract.InterceptorRefs = new InterceptorRefElementCollection();
                    interceptMethodAddToContract.InterceptorRefs.Add(new InterceptorRefElement {Name = name});
                    interceptContractAdd.Methods.Add(interceptMethodAddToContract);
                    config.Interception.Contracts.Add(interceptContractAdd);
                }
            }
            else
            {
                config.Interception = new InterceptionElement();
                config.Interception.Contracts = new InterceptContractElementCollection();
                var interceptContractAdd = new InterceptContractElement();
                interceptContractAdd.Type = contractType.AssemblyQualifiedName;
                interceptContractAdd.Methods = new InterceptMethodElementCollection();
                var interceptMethodAddToContract = new InterceptMethodElement();
                interceptMethodAddToContract.Signature = method.GetSignature();
                interceptMethodAddToContract.InterceptorRefs = new InterceptorRefElementCollection();
                interceptMethodAddToContract.InterceptorRefs.Add(new InterceptorRefElement {Name = name});
                interceptContractAdd.Methods.Add(interceptMethodAddToContract);
                config.Interception.Contracts.Add(interceptContractAdd);
            }
        }
    }
}