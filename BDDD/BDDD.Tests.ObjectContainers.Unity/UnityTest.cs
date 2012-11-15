using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDDD.Application;
using BDDD.Config;
using BDDD.ObjectContainer;
using BDDD.Tests.Common.Configuration;

namespace BDDD.Tests.ObjectContainers.Unity
{
    [TestClass]
    public class UnityTest
    {
        [TestMethod]
        public void StartApp()
        {
            App app = AppRuntime.Create(ConfigHelper.GetAppConfigSource());
            app.Start();
        }
    }
}
