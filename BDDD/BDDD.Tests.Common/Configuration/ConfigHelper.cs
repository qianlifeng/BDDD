using BDDD.Config;
using BDDD.ObjectContainers.Unity;

namespace BDDD.Tests.Common.Configuration
{
    public class ConfigHelper
    {
        public static ManualConfigSource GetManualConfigSource()
        {
            var source = new ManualConfigSource();
            source.ObjectContainer = typeof (UnityObjectContainer);
            return source;
        }

        /// <summary>
        ///     从配置文件中获得配置信息
        /// </summary>
        /// <returns></returns>
        public static IConfigSource GetAppConfigSource()
        {
            return new AppConfigSource();
        }
    }
}