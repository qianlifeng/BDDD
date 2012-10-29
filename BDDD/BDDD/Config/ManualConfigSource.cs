using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using System.Reflection;

namespace BDDD.Config
{
    /// <summary>
    /// 允许以编程的方式设置和框架读取配置信息
    /// </summary>
    public class ManualConfigSource : IConfigSource
    {
        private readonly BDDDConfigSection config;

        public BDDDConfigSection Config
        {
            get { return config; }
        }

        public Type ObjectContainer
        {
            get { return Type.GetType(config.ObjectContainer.Provider); }
            set { config.ObjectContainer.Provider = value.AssemblyQualifiedName; }
        }

        public ManualConfigSource()
        {
            config = new BDDDConfigSection();
            config.Interception = new InterceptionElement();
            config.Interception.Interceptors = new InterceptorElementCollection();
        }

        /// <summary>
        /// 向配置信息中添加一个拦截器
        /// </summary>
        /// <param name="name">拦截器的名字</param>
        /// <param name="interceptorType">拦截器类型</param>
        public void AddInterceptor(string name, Type interceptorType)
        {
            if (!typeof(IInterceptor).IsAssignableFrom(interceptorType))
                throw new ConfigException("'{0}' 不是一个可用的拦截类型", interceptorType);

            if (this.config.Interception == null)
                this.config.Interception = new InterceptionElement();
            if (this.config.Interception.Interceptors == null)
                this.config.Interception.Interceptors = new InterceptorElementCollection();
            //如果已经存在相同名字或者类型的拦截器，则直接返回
            foreach (InterceptorElement interceptor in config.Interception.Interceptors)
            {
                if (interceptor.Name.Equals(name) || interceptor.Type.Equals(interceptorType.AssemblyQualifiedName))
                    return;
            }
            InterceptorElement interceptorAdd = new InterceptorElement();
            interceptorAdd.Name = name;
            interceptorAdd.Type = interceptorType.AssemblyQualifiedName;
            config.Interception.Interceptors.Add(interceptorAdd);
        }

        /// <summary>
        /// 向配置信息中添加一个拦截器
        /// </summary>
        /// <param name="interceptorType">拦截器类型</param>
        public void AddInterceptor(Type interceptorType)
        {
            AddInterceptor(interceptorType.AssemblyQualifiedName, interceptorType);
        }

        /// <summary>
        /// 为制定类型的指定方法添加拦截器
        /// </summary>
        /// <param name="contractType">需要拦截方法的类型</param>
        /// <param name="method">需要拦截的方法</param>
        /// <param name="name">拦截器的名字</param>
        public void AddInterceptorRef(Type contractType, MethodInfo method, string name)
        {
            if (this.config.Interception != null)
            {
                if (this.config.Interception.Contracts != null)
                {
                    foreach (InterceptContractElement interceptContract in this.config.Interception.Contracts)
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
                                            foreach (InterceptorRefElement interceptorRef in interceptMethod.InterceptorRefs)
                                            {
                                                if (interceptorRef.Name.Equals(name))
                                                    return;
                                            }
                                            interceptMethod.InterceptorRefs.Add(new InterceptorRefElement { Name = name });
                                        }
                                        else
                                        {
                                            interceptMethod.InterceptorRefs = new InterceptorRefElementCollection();
                                            interceptMethod.InterceptorRefs.Add(new InterceptorRefElement { Name = name });
                                        }
                                        return;
                                    }
                                }
                                InterceptMethodElement interceptMethodAdd = new InterceptMethodElement();
                                interceptMethodAdd.Signature = method.GetSignature();
                                interceptMethodAdd.InterceptorRefs = new InterceptorRefElementCollection();
                                interceptMethodAdd.InterceptorRefs.Add(new InterceptorRefElement { Name = name });
                                interceptContract.Methods.Add(interceptMethodAdd);
                            }
                            else
                            {
                                interceptContract.Methods = new InterceptMethodElementCollection();
                                InterceptMethodElement interceptMethodAdd = new InterceptMethodElement();
                                interceptMethodAdd.Signature = method.GetSignature();
                                interceptMethodAdd.InterceptorRefs = new InterceptorRefElementCollection();
                                interceptMethodAdd.InterceptorRefs.Add(new InterceptorRefElement { Name = name });
                                interceptContract.Methods.Add(interceptMethodAdd);
                            }
                            return;
                        }
                    }
                    InterceptContractElement interceptContractAdd = new InterceptContractElement();
                    interceptContractAdd.Type = contractType.AssemblyQualifiedName;
                    interceptContractAdd.Methods = new InterceptMethodElementCollection();
                    InterceptMethodElement interceptMethodAddToContract = new InterceptMethodElement();
                    interceptMethodAddToContract.Signature = method.GetSignature();
                    interceptMethodAddToContract.InterceptorRefs = new InterceptorRefElementCollection();
                    interceptMethodAddToContract.InterceptorRefs.Add(new InterceptorRefElement { Name = name });
                    interceptContractAdd.Methods.Add(interceptMethodAddToContract);
                    this.config.Interception.Contracts.Add(interceptContractAdd);
                }
                else
                {
                    this.config.Interception.Contracts = new InterceptContractElementCollection();
                    InterceptContractElement interceptContractAdd = new InterceptContractElement();
                    interceptContractAdd.Type = contractType.AssemblyQualifiedName;
                    interceptContractAdd.Methods = new InterceptMethodElementCollection();
                    InterceptMethodElement interceptMethodAddToContract = new InterceptMethodElement();
                    interceptMethodAddToContract.Signature = method.GetSignature();
                    interceptMethodAddToContract.InterceptorRefs = new InterceptorRefElementCollection();
                    interceptMethodAddToContract.InterceptorRefs.Add(new InterceptorRefElement { Name = name });
                    interceptContractAdd.Methods.Add(interceptMethodAddToContract);
                    this.config.Interception.Contracts.Add(interceptContractAdd);
                }
            }
            else
            {
                this.config.Interception = new InterceptionElement();
                this.config.Interception.Contracts = new InterceptContractElementCollection();
                InterceptContractElement interceptContractAdd = new InterceptContractElement();
                interceptContractAdd.Type = contractType.AssemblyQualifiedName;
                interceptContractAdd.Methods = new InterceptMethodElementCollection();
                InterceptMethodElement interceptMethodAddToContract = new InterceptMethodElement();
                interceptMethodAddToContract.Signature = method.GetSignature();
                interceptMethodAddToContract.InterceptorRefs = new InterceptorRefElementCollection();
                interceptMethodAddToContract.InterceptorRefs.Add(new InterceptorRefElement { Name = name });
                interceptContractAdd.Methods.Add(interceptMethodAddToContract);
                this.config.Interception.Contracts.Add(interceptContractAdd);
            }
        }
    }
}
