using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.ObjectContainer
{
    public interface IObjectContainer:IServiceProvider
    {
        T GetService<T>() where T : class;

        /// <summary>
        /// 得到具体实现的ObjectContainer实例，
        /// 利用此对象获得不同IOC容器的特性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetRealObjectContainer<T>() where T : class;
    }
}
