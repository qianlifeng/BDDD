using System;
using System.Linq;
using System.Reflection;
using BDDD.Application;
using BDDD.Config;
using BDDD.Interception;
using BDDD.ObjectContainer;
using BDDD.Repository;
using BDDD.Repository.NHibernate;
using BDDD.Tests.Common.Configuration;
using BDDD.Tests.DomainModel;
using BDDD.Tests.DomainModel.NHibernateMapper;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cfg;

namespace BDDD.Tests.Interceptions
{
    [TestClass]
    public class AddInterceptions
    {
        private static Configuration nhibernateCfg;

        [ClassInitialize]
        public static void InitialData(TestContext context)
        {
            nhibernateCfg = Fluently.Configure()
                                    .Database(
                                        MsSqlConfiguration.MsSql2008
                                                          .ConnectionString(s => s.Server("localhost")
                                                                                  .Database("BDDD_NHibernate")
                                                                                  .TrustedConnection())
                )
                                    .Mappings(m => m.FluentMappings.AddFromAssembly(typeof (CustomerMap).Assembly)
                                                    .Conventions.Add(ForeignKey.EndsWith("Id"))
                )
                                    .BuildConfiguration();
        }

        [TestInitialize]
        public void ResetApp()
        {
            if (AppRuntime.Instance.CurrentApplication != null)
            {
                AppRuntime.Instance.CloseCurrentApplication();
            }
        }

        [TestMethod]
        [Description("添加拦截器测试")]
        public void AddInterceptor()
        {
            ManualConfigSource configSource = ConfigHelper.GetManualConfigSource();
            configSource.AddInterceptor("ExceptionHandler", typeof (ExceptionHandlerInterceptor));

            App app = AppRuntime.Create(configSource);
            app.Start();

            Assert.AreEqual(1, app.Interceptors.Count());
        }

        [TestMethod]
        [Description("添加拦截器测试_添加拦截任务")]
        public void AddInterceptor_AddInterceptorRef()
        {
            Type typeWantToIntercept = typeof (IRepositoryContext);
            MethodInfo addMethod = typeWantToIntercept.GetMethod("RegisterNew",
                                                                 BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(addMethod);

            ManualConfigSource configSource = ConfigHelper.GetManualConfigSource();
            configSource.AddInterceptor(typeof (ExceptionHandlerInterceptor));
            configSource.AddInterceptorRef(typeWantToIntercept, addMethod,
                                           typeof (ExceptionHandlerInterceptor).AssemblyQualifiedName);
            App app = AppRuntime.Create(configSource);
            app.Start();

            Assert.AreEqual(1, app.Interceptors.Count());
            Assert.AreEqual(typeWantToIntercept.AssemblyQualifiedName,
                            app.ConfigSource.Config.Interception.Contracts.GetItemAt(0).Type);
        }

        [TestMethod]
        [Description("测试拦截器是否可用")]
        public void AddInterceptor_TestInterceptor()
        {
            Type typeWantToIntercept = typeof (IUnitOfWork);
            MethodInfo addMethod = typeWantToIntercept.GetMethod("Commit", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(addMethod);

            ManualConfigSource configSource = ConfigHelper.GetManualConfigSource();
            configSource.AddInterceptor("TestHandler", typeof (TestInterceptor));
            configSource.AddInterceptorRef(typeWantToIntercept, addMethod, "TestHandler");

            App app = AppRuntime.Create(configSource);
            app.Start();
            var container =
                AppRuntime.Instance.CurrentApplication.ObjectContainer.GetRealObjectContainer<UnityContainer>();
            container.RegisterType<INHibernateConfiguration, NHibernateConfiguration>(
                new InjectionConstructor(nhibernateCfg));
            container.RegisterType<IRepositoryContext, NHibernateContext>(
                new InjectionConstructor(new ResolvedParameter<INHibernateConfiguration>()));

            using (var context = ServiceLocator.Instance.GetService<IRepositoryContext>())
            {
                IRepository<ItemCategory> customerRepository = context.GetRepository<ItemCategory>();
                var itemCategory = new ItemCategory {CategoryName = "日常用品"};

                //这里的cutsomerRepository没有使用透明代理，所以他的方法不会被拦截
                customerRepository.Add(itemCategory);
                context.Commit();
            }

            Assert.IsTrue(TestInterceptor.execCount == 1);
        }
    }
}