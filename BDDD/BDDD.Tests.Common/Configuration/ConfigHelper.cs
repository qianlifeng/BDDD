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
    }
}
