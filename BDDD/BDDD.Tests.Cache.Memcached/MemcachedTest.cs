using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDDD.Config;
using BDDD.Application;
using BDDD.Tests.Common.Configuration;
using Microsoft.Practices.Unity;
using BDDD.Cache;
using BDDD.Cache.Memcached;
using BDDD.Tests.DomainModel;
using BDDD.ObjectContainer;

namespace BDDD.Tests.Cache.Memcached
{
    /// <summary>
    /// Summary description for UnitTest1
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

            UnityContainer c = application.ObjectContainer.GetRealObjectContainer<UnityContainer>();
            c.RegisterType<ICache, MemcachedCache>();
            c.RegisterType<AbsoluteTimeExpiration, MemcachedAbsoluteTimeExpiration>("SCache",
                new InjectionConstructor(TimeSpan.FromSeconds(5)));
            c.RegisterType<AbsoluteTimeExpiration, MemcachedAbsoluteTimeExpiration>("S1Cache",
                new InjectionConstructor(TimeSpan.FromSeconds(15)));
        }

        [TestMethod]
        [Description("测试添加缓存")]
        public void AddCache()
        {
            Customer c = new Customer("scott1", 10);
            BDDD.Cache.CacheManager.AddCache("test1", c, 
                ServiceLocator.Instance.GetService<AbsoluteTimeExpiration>("SCache"));

            Customer cachedCustomer = BDDD.Cache.CacheManager.GetCache<Customer>("test1");
            Assert.IsNotNull(cachedCustomer);
            Assert.AreEqual<string>(cachedCustomer.Name, "scott1");
        }
    }
}
