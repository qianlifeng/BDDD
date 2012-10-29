using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using BDDD.ObjectContainer;
using BDDD.Config;

namespace BDDD.Application
{
    public class App
    {
        private IConfigSource configSource;
        private IObjectContainer objectContainer;
        private List<IInterceptor> interceptors;

        public App(IConfigSource configSource)
        {
            if (configSource == null)
                throw new ArgumentNullException("configSource 为空");
            if (configSource.Config == null)
                throw new ConfigException("没有定义配置信息");
            if (configSource.Config.Application == null)
                throw new ConfigException("当前配置文件中没有定义Application信息");
            if (configSource.Config.ObjectContainer == null)
                throw new ConfigException("当前配置文件中没有定义ObjectContainer信息");
            if (string.IsNullOrEmpty(configSource.Config.ObjectContainer.Provider))
                throw new ConfigException("当前配置文件中没有定义ObjectContainer的Provider信息");

            //从配置文件中加载ObjectContainer
            Type objectContainerType = Type.GetType(configSource.Config.ObjectContainer.Provider);
            if (objectContainerType == null)
                throw new ConfigException("没有找到类型为{0}的ObjectContainer", configSource.Config.ObjectContainer.Provider);
            this.objectContainer = Activator.CreateInstance(objectContainerType) as ObjectContainer.ObjectContainer;

            //从配置文件中加载Interceptors
            this.interceptors = new List<IInterceptor>();
            if (this.configSource.Config.Interception != null && this.configSource.Config.Interception.Interceptors != null)
            {
                foreach (InterceptorElement interceptorElement in this.configSource.Config.Interception.Interceptors)
                {
                    Type interceptorType = Type.GetType(interceptorElement.Type);
                    if (interceptorType == null)
                        throw new ConfigException("找不到类型为{0}的拦截器", interceptorElement.Type);
                    IInterceptor interceptor = (IInterceptor)Activator.CreateInstance(interceptorType);
                    this.interceptors.Add(interceptor);
                }
            }

            this.configSource = configSource;
        }

        public IConfigSource ConfigSource
        {
            get { return configSource; }
        }

        public IObjectContainer ObjectContainer
        {
            get { return objectContainer; }
        }

        public IEnumerable<IInterceptor> Interceptors
        {
            get { return interceptors; }
        }

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}
