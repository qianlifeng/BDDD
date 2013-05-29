using BDDD.Application;
using BDDD.ObjectContainer;
using BDDD.Repository;
using BDDD.Tests.Common.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BDDD.Tests.ObjectContainers.Unity
{
    [TestClass]
    public class UnityTest
    {
        [TestMethod]
        [Description("从配置文件中获得Ioc注册信息")]
        public void GetContainerFromFile()
        {
            AppRuntime.Create(ConfigHelper.GetAppConfigSource()).Start();

            var context = ServiceLocator.Instance.GetService<IRepositoryContext>();
            Assert.IsNotNull(context);
        }
    }
}