using System;
using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace BDDD.ObjectContainers.Unity
{
    public class UnityObjectContainer : ObjectContainer.ObjectContainer
    {
        private readonly IUnityContainer realUnityContainer;
        private Guid id;

        public UnityObjectContainer()
        {
            id = Guid.NewGuid();
            realUnityContainer = new UnityContainer();
        }

        protected override T DoGetService<T>()
        {
            return realUnityContainer.Resolve<T>();
        }

        protected override T DoGetService<T>(string name)
        {
            return realUnityContainer.Resolve<T>(name);
        }

        protected override object DoGetService(Type serviceType)
        {
            return realUnityContainer.Resolve(serviceType);
        }

        protected override T DoGetRealObjectContainer<T>()
        {
            if (typeof (T).Equals(typeof (UnityContainer)))
                return realUnityContainer as T;
            throw new BDDDException("当前的传入的类型应该是 '{0}' 类型.", typeof (UnityContainer));
        }

        protected override void DoInitializeFromConfigFile(string configSectionName)
        {
            var section = (UnityConfigurationSection) ConfigurationManager.GetSection(configSectionName);
            section.Configure(realUnityContainer);
        }
    }
}