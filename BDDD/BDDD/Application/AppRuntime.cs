using BDDD.Config;

namespace BDDD.Application
{
    public sealed class AppRuntime
    {
        private static readonly AppRuntime instance = new AppRuntime();
        private static readonly object lockObj = new object();

        private App currentApplication;

        private AppRuntime()
        {
        }

        public static AppRuntime Instance
        {
            get { return instance; }
        }

        public App CurrentApplication
        {
            get { return instance.currentApplication; }
        }

        public static App Create(IConfigSource configSource)
        {
            lock (lockObj)
            {
                if (instance.currentApplication == null)
                {
                    lock (lockObj)
                    {
                        if (configSource.Config == null)
                            throw new ConfigException("configSource的配置信息不存在");
                        instance.currentApplication = new App(configSource);
                    }
                }
            }
            return instance.currentApplication;
        }

        public void CloseCurrentApplication()
        {
            currentApplication = null;
        }
    }
}