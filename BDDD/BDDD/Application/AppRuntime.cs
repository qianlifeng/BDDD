using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDD.Config;

namespace BDDD.Application
{
    public sealed class AppRuntime
    {
        private static readonly AppRuntime instance = new AppRuntime();
        private static readonly object lockObj = new object();

        private App currentApplication = null;

        private AppRuntime() { }

        public static AppRuntime Instance
        {
            get
            {
                return instance;
            }
        }

        public App CurrentApplication
        {
            get { return currentApplication; }
        }

        public static App Create(IConfigSource configSource)
        {
            lock (lockObj)
            {
                if (instance.currentApplication == null)
                {
                    lock (lockObj)
                    {
                        if (configSource.Config == null || configSource.Config.Application == null)
                            throw new ConfigException("configSource中的application配置信息不存在");
                        string typeName = configSource.Config.Application.Provider;
                        if (string.IsNullOrEmpty(typeName))
                            throw new ConfigException("应用程序的Application provider没有配置");
                        Type type = Type.GetType(typeName);
                        if (type == null)
                            throw new BDDDException("配置错误，不存在应用程序类型：{0}", typeName);
                        instance.currentApplication = (App)Activator.CreateInstance(type, new object[] { configSource });
                    }
                }
            }
            return instance.currentApplication;
        }
    }
}
