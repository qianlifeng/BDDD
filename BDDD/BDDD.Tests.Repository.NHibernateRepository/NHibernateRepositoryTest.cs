using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BDDD.Repository;
using BDDD.Application;
using BDDD.Config;
using BDDD.Tests.Common.Configuration;
using BDDD.Tests.DomainModel;
using Microsoft.Practices.Unity;
using BDDD.Repository.NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Automapping;

namespace BDDD.Tests.Repository.NHibernateRepository
{
    [TestClass]
    public class NHibernateRepositoryTest
    {
        App application;

        public NHibernateRepositoryTest()
        {
            ManualConfigSource configSource = ConfigHelper.GetManualConfigSource();
            application = AppRuntime.Create(configSource);
            application.AppInitEvent += new App.AppInitHandle(application_AppInitEvent);
            application.Start();
        }

        void application_AppInitEvent(IConfigSource source, ObjectContainer.IObjectContainer objectContainer)
        {
            NHibernate.Cfg.Configuration nhibernateCfg = Helper.SetupNHibernateDatabase();

            UnityContainer c = objectContainer.GetRealObjectContainer<UnityContainer>();
            c.RegisterInstance<NHibernate.Cfg.Configuration>(nhibernateCfg)
            .RegisterType<IRepositoryContext, NHibernateContext>(new InjectionConstructor(new ResolvedParameter<NHibernate.Cfg.Configuration>()))
            .RegisterType<IRepository<Customer>, NHibernateRepository<Customer>>();
        }

        [TestMethod]
        [Description("添加聚合根")]
        public void NHibernateRepositoryTest_AddAggregateRootToRepository()
        {
            using (IRepositoryContext ctx = application.ObjectContainer.GetService<IRepositoryContext>())
            {
                IRepository<Customer> customerRepository = ctx.GetRepository<Customer>();
                Customer u = new Customer("scott", 12);
                customerRepository.Add(u);
                ctx.Commit();
                Assert.IsNotNull(u.ID);
            }
        }
    }
}
