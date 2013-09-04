using System;
using BDDD.Application;
using BDDD.Cache;
using BDDD.Cache.Memcached;
using BDDD.Config;
using BDDD.ObjectContainer;
using BDDD.Tests.Common.Configuration;
using BDDD.Tests.DomainModel;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BDDD.Tests.Cache.Memcached
{
    /// <summary>
    ///     Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class MemcachedTest
    {
        private static App application;

        [ClassInitialize]
        public static void Initial(TestContext context)
        {
            ManualConfigSource configSource = ConfigHelper.GetManualConfigSource();
            application = AppRuntime.Create(configSource);
            application.Start();

            var c = application.ObjectContainer.GetRealObjectContainer<UnityContainer>();
            c.RegisterType<ICache, MemcachedCache>();
            c.RegisterType<AbsoluteTimeExpiration, MemcachedAbsoluteTimeExpiration>("SCache",
                                                                                    new InjectionConstructor(
                                                                                        TimeSpan.FromSeconds(5)));
            c.RegisterType<AbsoluteTimeExpiration, MemcachedAbsoluteTimeExpiration>("S1Cache",
                                                                                    new InjectionConstructor(
                                                                                        TimeSpan.FromSeconds(15)));
        }

        [TestMethod]
        [Description("测试添加缓存")]
        public void AddCache()
        {
            //todo:需要首先安装Memcached
            //var c = new Customer("scott1", 10);
            //CacheManager.AddCache("test1", c,
            //                      ServiceLocator.Instance.GetService<AbsoluteTimeExpiration>("SCache"));

            //var cachedCustomer = CacheManager.GetCache<Customer>("test1");
            //Assert.IsNotNull(cachedCustomer);
            //Assert.AreEqual(cachedCustomer.Name, "scott1");
        }
    }
}