using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDD.Application;

namespace BDDD.ObjectContainer
{
    public class ServiceLocator : ObjectContainer
    {
        private readonly IObjectContainer objectContainer = AppRuntime.Instance.CurrentApplication.ObjectContainer;
        private static readonly ServiceLocator instance = new ServiceLocator();

        private ServiceLocator() { }

        public static ServiceLocator Instance
        {
            get { return instance; }
        }

        protected override T DoGetService<T>()
        {
            return objectContainer.GetService<T>();
        }

        protected override object DoGetService(Type serviceType)
        {
            return objectContainer.GetService(serviceType);
        }
    }
}
