using System;
using System.Collections.Generic;
using BDDD.Config;
using BDDD.ObjectContainer;
using Castle.DynamicProxy;

namespace BDDD.Application
{
    public sealed class App
    {
        public delegate void AppInitHandle(IConfigSource source, IObjectContainer objectContainer);

        private readonly IConfigSource configSource;
        private readonly List<IInterceptor> interceptors = new List<IInterceptor>();
        private readonly IObjectContainer objectContainer;
        private Guid id;

        public App(IConfigSource configSource)
        {
            id = Guid.NewGuid();
            if (configSource == null)
                throw new ArgumentNullException("configSource 为空");
            if (configSource.Config == null)
                throw new ConfigException("没有定义配置信息");
            if (configSource.Config.ObjectContainer == null)
                throw new ConfigException("当前配置文件中没有定义ObjectContainer信息");
            if (string.IsNullOrEmpty(configSource.Config.ObjectContainer.Provider))
                throw new ConfigException("当前配置文件中没有定义ObjectContainer的Provider信息");

            this.configSource = configSource;

            //从配置文件中加载ObjectContainer
            Type objectContainerType = Type.GetType(configSource.Config.ObjectContainer.Provider);
            if (objectContainerType == null)
                throw new ConfigException("没有找到类型为{0}的ObjectContainer", configSource.Config.ObjectContainer.Provider);
            objectContainer = Activator.CreateInstance(objectContainerType) as ObjectContainer.ObjectContainer;
            //如果需要从配置文件中加载映射关系
            if (configSource.Config.ObjectContainer.InitFromConfigFile)
            {
                string sectionName = configSource.Config.ObjectContainer.SectionName;
                if (!string.IsNullOrEmpty(sectionName))
                {
                    objectContainer.InitializeFromConfigFile(sectionName);
                }
                else
                    throw new ConfigException("当ObejctContainer配置信息中的InitFromConfigFile属性为true的时候，必须同时提供Section name属性");
            }

            //从配置文件中加载Interceptors
            if (configSource.Config.Interception != null
                && configSource.Config.Interception.Interceptors != null)
            {
                foreach (InterceptorElement interceptorElement in configSource.Config.Interception.Interceptors)
                {
                    Type interceptorType = Type.GetType(interceptorElement.Type);
                    if (interceptorType == null)
                        throw new ConfigException("找不到类型为{0}的拦截器", interceptorElement.Type);
                    var interceptor = (IInterceptor) Activator.CreateInstance(interceptorType);
                    interceptors.Add(interceptor);
                }
            }
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

        public event AppInitHandle AppInitEvent;

        private void HandleAppInitEvent()
        {
            if (AppInitEvent != null)
            {
                AppInitEvent(configSource, objectContainer);
            }
        }

        /// <summary>
        ///     启动框架
        /// </summary>
        public void Start()
        {
            HandleAppInitEvent();
        }
    }
}