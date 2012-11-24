using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDDD.Cache;
using BDDD.Tests.DomainModel;
using BDDD.Tests.Common.Configuration;
using BDDD.Config;
using BDDD.Application;
using Microsoft.Practices.Unity;
using BDDD.Cache.MSEnterpriseLibrary;
using BDDD.ObjectContainer;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using System.Threading;

namespace BDDD.Tests.Cache.MSEL
{
    [TestClass]
    public class CacheTests
    {
        private static App application;

        [ClassInitialize]
        public static void Initial(TestContext context)
        {
            ManualConfigSource configSource = ConfigHelper.GetManualConfigSource();
            application = AppRuntime.Create(configSource);
            application.Start();

            UnityContainer c = application.ObjectContainer.GetRealObjectContainer<UnityContainer>();
            c.RegisterType<ICache, MSELCache>();
            c.RegisterType<AbsoluteTimeExpiration, MSELAbsoluteTimeExpiration>("SCache",
                new InjectionConstructor(TimeSpan.FromSeconds(5)));
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

        [TestMethod]
        [Description("测试移除缓存")]
        public void RemoveCache()
        {
            Customer c = new Customer("scott1", 10);
            BDDD.Cache.CacheManager.AddCache("test1", c,
                ServiceLocator.Instance.GetService<AbsoluteTimeExpiration>("SCache"));

            Customer cachedCustomer = BDDD.Cache.CacheManager.GetCache<Customer>("test1");
            Assert.IsNotNull(cachedCustomer);
            Assert.AreEqual<string>(cachedCustomer.Name, "scott1");

            BDDD.Cache.CacheManager.RemoveCache("test1");
            Customer shouldNull = BDDD.Cache.CacheManager.GetCache<Customer>("test1");
            Assert.IsNull(shouldNull);
        }

        [TestMethod]
        [Description("测试缓存的过期策略_绝对时间")]
        public void AddCache_AbsoluteExpiration()
        {
            Customer c = new Customer("scott1", 10);
            AbsoluteTimeExpiration expiration = ServiceLocator.Instance.GetService<AbsoluteTimeExpiration>("SCache");
            BDDD.Cache.CacheManager.AddCache("test1", c, expiration);

            int i = 0;
            while (i++ < 20)
            {
                Customer cachedCustomer = BDDD.Cache.CacheManager.GetCache<Customer>("test1");

                Console.WriteLine(DateTime.Now.ToString());
                Assert.IsNotNull(cachedCustomer);
                Assert.AreEqual<string>(cachedCustomer.Name, "scott1");

                Thread.Sleep(1000);
            }
        }
    }
}
