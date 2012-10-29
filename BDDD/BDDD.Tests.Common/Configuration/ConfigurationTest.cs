using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDDD.ObjectContainer;
using BDDD.Config;
using BDDD.Application;

namespace BDDD.Tests.Common.Configuration
{
    [TestClass]
    public class ConfigurationTest
    {
        [TestMethod()]
        [Description("测试Specification的Or功能")]
        public void OrTest()
        {
            ManualConfigSource configSource = new BDDD.Config.ManualConfigSource();
           AppRuntime.Instance.(configSource);
        }
    }
}
