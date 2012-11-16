using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace BDDD.ObjectContainers.Unity
{
    public class UnityObjectContainer : ObjectContainer.ObjectContainer
    {
        private readonly IUnityContainer container;

        public UnityObjectContainer()
        {
            container = new Microsoft.Practices.Unity.UnityContainer();
        }

        protected override T DoGetService<T>()
        {
            return container.Resolve<T>();
        }

        protected override object DoGetService(Type serviceType)
        {
            return container.Resolve(serviceType);
        }

        protected override T DoGetRealObjectContainer<T>()
        {
            if (typeof(T).Equals(typeof(UnityContainer)))
                return (T)this.container;
            throw new BDDDException("当前的传入的类型应该是 '{0}' 类型.", typeof(UnityContainer));
        }

        protected override void DoInitializeFromConfigFile(string configSectionName)
        {
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection(configSectionName);
            section.Configure(container);
        }
    }
}
