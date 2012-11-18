using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDDD.Tests.Common.Configuration;
using BDDD.Config;
using BDDD.Interception;
using BDDD.Application;
using BDDD.Repository;
using System.Reflection;
using Microsoft.Practices.Unity;
using BDDD.Repository.NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using BDDD.Tests.DomainModel.NHibernateMapper;
using BDDD.ObjectContainer;
using BDDD.Tests.DomainModel;

namespace BDDD.Tests.Interceptions
{
    [TestClass]
    public class AddInterceptions
    {

        static NHibernate.Cfg.Configuration nhibernateCfg;

        [ClassInitialize]
        public static void InitialData(TestContext context)
        {
            nhibernateCfg = Fluently.Configure()
                 .Database(
                     FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2008
                         .ConnectionString(s => s.Server("localhost")
                                 .Database("BDDD_NHibernate")
                                 .TrustedConnection())
                 )
                 .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(CustomerMap).Assembly)
                     .Conventions.Add(ForeignKey.EndsWith("Id"))
                     )
                 .BuildConfiguration();
        }

        [TestMethod]
        [Description("添加拦截器测试")]
        public void AddInterceptor()
        {
            ManualConfigSource configSource = ConfigHelper.GetManualConfigSource();
            configSource.AddInterceptor("ExceptionHandler", typeof(ExceptionHandlerInterceptor));

            App app = AppRuntime.Create(configSource);
            app.Start();

            Assert.AreEqual<int>(1, app.Interceptors.Count());
        }

        [TestMethod]
        [Description("添加拦截器测试_添加拦截任务")]
        public void AddInterceptor_AddInterceptorRef()
        {
            Type typeWantToIntercept = typeof(IRepositoryContext);
            MethodInfo addMethod = typeWantToIntercept.GetMethod("RegisterNew", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(addMethod);

            ManualConfigSource configSource = ConfigHelper.GetManualConfigSource();
            configSource.AddInterceptor(typeof(ExceptionHandlerInterceptor));
            configSource.AddInterceptorRef(typeWantToIntercept, addMethod, "ExceptionHandler");

            App app = AppRuntime.Create(configSource);
            app.Start();

            Assert.AreEqual<int>(1, app.Interceptors.Count());
            Assert.AreEqual<string>(app.ConfigSource.Config.Interception.Contracts.GetItemAt(0).Type,
                typeWantToIntercept.AssemblyQualifiedName);
        }

        [TestMethod]
        [Description("测试拦截器是否可用")]
        public void AddInterceptor_TestInterceptor()
        {
            Type typeWantToIntercept = typeof(IRepositoryContext);
            MethodInfo addMethod = typeWantToIntercept.GetMethod("RegisterNew", BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(addMethod);

            ManualConfigSource configSource = ConfigHelper.GetManualConfigSource();
            configSource.AddInterceptor("ExceptionHandler", typeof(ExceptionHandlerInterceptor));
            configSource.AddInterceptorRef(typeWantToIntercept, addMethod, "ExceptionHandler");

            App app = AppRuntime.Create(configSource);
            app.Start();
            UnityContainer container = AppRuntime.Instance.CurrentApplication.ObjectContainer.GetRealObjectContainer<UnityContainer>();
            container.RegisterType<INHibernateConfiguration, NHibernateConfiguration>(
                new InjectionConstructor(nhibernateCfg));
            container.RegisterType<IRepositoryContext, NHibernateContext>(
                new InjectionConstructor(new ResolvedParameter<INHibernateConfiguration>()));

            using (IRepositoryContext context = ServiceLocator.Instance.GetService<IRepositoryContext>())
            {
                IRepository<ItemCategory> customerRepository = context.GetRepository<ItemCategory>();
                ItemCategory itemCategory = new ItemCategory { CategoryName = "日常用品" };

                customerRepository.Add(itemCategory);
                context.Commit();
            }
        }
    }
}
