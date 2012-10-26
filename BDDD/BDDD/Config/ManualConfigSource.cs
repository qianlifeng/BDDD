using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;

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

        public ManualConfigSource()
        {
            config = new BDDDConfigSection();
            config.Application = new ApplicationElement();
            config.Interception = new InterceptionElement();
            config.Interception.Interceptors = new InterceptorElementCollection();
        }

        /// <summary>
        ///  获取或设置BDDD组建的提供者
        /// </summary>
        public Type Application
        {
            get { return Type.GetType(config.Application.Provider); }
            set { config.Application.Provider = value.AssemblyQualifiedName; }
        }

        /// <summary>
        /// 向配置信息中添加一个拦截器
        /// </summary>
        /// <param name="name"></param>
        /// <param name="interceptorType"></param>
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
    }
}
