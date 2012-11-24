using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.ObjectContainer
{
    public interface IObjectContainer : IServiceProvider
    {
        T GetService<T>() where T : class;

        /// <summary>
        /// 从容器中根据指定的名字获得已注册的对象，
        /// 某些情况下存在需要同时用到一个接口的多个实现类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        T GetService<T>(string name) where T : class;

        /// <summary>
        /// 具有从配置文件加载依赖关系的能力
        /// </summary>
        /// <param name="configSectionName"></param>
        void InitializeFromConfigFile(string configSectionName);

        /// <summary>
        /// 得到具体实现的ObjectContainer实例，
        /// 利用此对象获得不同IOC容器的特性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetRealObjectContainer<T>() where T : class;
    }
}
