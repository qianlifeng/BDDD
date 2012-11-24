using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDD.Application;

namespace BDDD.ObjectContainer
{
    /// <summary>
    /// 提供了一种从IOC容器中获得对象的便捷方式
    /// </summary>
    public class ServiceLocator
    {
        private readonly IObjectContainer objectContainer = AppRuntime.Instance.CurrentApplication.ObjectContainer;
        private static readonly ServiceLocator instance = new ServiceLocator();

        private ServiceLocator() { }

        public static ServiceLocator Instance   
        {
            get { return instance; }
        }

        public  T GetService<T>() where T : class
        {
            return objectContainer.GetService<T>();
        }

        public  T GetService<T>(string name) where T : class
        {
            return objectContainer.GetService<T>(name);
        }
    }
}
