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
            UnityContainer c = objectContainer.GetRealObjectContainer<UnityContainer>();

            NHibernate.Cfg.Configuration nhibernateCfg = Fluently.Configure()
                   .Database(
                       FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2008
                           .ConnectionString(s => s.Server("127.0.0.1")
                                   .Database("BDDD_NHibernate")
                                   .TrustedConnection())
                   )
                   .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<Customer>()))
                   .BuildConfiguration();

            NHibernate.Tool.hbm2ddl.SchemaExport schemaExport = new NHibernate.Tool.hbm2ddl.SchemaExport(nhibernateCfg);
            schemaExport.Execute(false, true, false);

            c.RegisterInstance<NHibernate.Cfg.Configuration>(nhibernateCfg)
            .RegisterType<IRepositoryContext, NHibernateContext>(new InjectionConstructor(new ResolvedParameter<NHibernate.Cfg.Configuration>()))
                //.RegisterType<IRepository<Customer>, NHibernateRepository<Customer>>(new InjectionConstructor(new ResolvedParameter<IRepositoryContext>()));
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
