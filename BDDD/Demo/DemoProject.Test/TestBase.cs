using AutoMapper;
using BDDD.Application;
using BDDD.Config;
using BDDD.ObjectContainer;
using BDDD.ObjectContainers.Unity;
using BDDD.Repository;
using BDDD.Repository.NHibernate;
using DemoProject.Application;
using DemoProject.DTO;
using DemoProject.Domain.Model;
using DemoProject.Domain.Repositories;
using DemoProject.Domain.Repository;
using DemoProject.IApplication;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Tool.hbm2ddl;
using Configuration = NHibernate.Cfg.Configuration;

namespace DemoProject.Test
{
    public class TestBase
    {
        private static Configuration nhibernateCfg;
        private static App application;

        public static Configuration GetNHibernateConfig()
        {
            if (nhibernateCfg != null) return nhibernateCfg;

            nhibernateCfg = Fluently.Configure()
                                    .Database(
                                        MsSqlConfiguration.MsSql2008
                                                          .ConnectionString(s => s.Server("localhost")
                                                                                  .Database("DemoProject")
                                                                                  .TrustedConnection())
                                                          .ShowSql()
                )
                                    .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<User>())
                )
                                    .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "web"))
                                    .BuildConfiguration();

            return nhibernateCfg;
        }

        public static void ResetDB()
        {
            Configuration config = GetNHibernateConfig();
            var schemaExport = new SchemaExport(config);
            schemaExport.Execute(false, true, false);
        }

        public static void InitAppRuntime()
        {
            ManualConfigSource configSource = new ManualConfigSource { ObjectContainer = typeof(UnityObjectContainer) };
            application = AppRuntime.Create(configSource);
            application.AppInitEvent += application_AppInitEvent;
            application.Start();
        }

        private static void application_AppInitEvent(IConfigSource source, IObjectContainer objectContainer)
        {
            var c = objectContainer.GetRealObjectContainer<UnityContainer>();
            c.RegisterType<INHibernateConfiguration, NHibernateConfiguration>(new InjectionConstructor(GetNHibernateConfig()));
            c.RegisterType<IRepositoryContext, NHibernateContext>(new InjectionConstructor(new ResolvedParameter<INHibernateConfiguration>()));

            c.RegisterType<IUserService, UserService>();
            c.RegisterType<IUserRepository, UserRepository>();
        }
    }
}