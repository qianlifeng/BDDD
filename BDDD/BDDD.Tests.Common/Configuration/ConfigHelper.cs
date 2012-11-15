using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDD.Config;

namespace BDDD.Tests.Common.Configuration
{
    public class ConfigHelper
    {
        public static ManualConfigSource GetManualConfigSource()
        {
            ManualConfigSource source = new ManualConfigSource();
            source.ObjectContainer = typeof(BDDD.ObjectContainers.Unity.UnityObjectContainer);
            return source;
        }

        /// <summary>
        /// 从配置文件中获得配置信息
        /// </summary>
        /// <returns></returns>
        public static IConfigSource GetAppConfigSource()
        {
            return new AppConfigSource();
        }
    }
}
