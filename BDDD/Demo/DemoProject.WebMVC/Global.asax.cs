using BDDD.Application;
using BDDD.Config;
using BDDD.ObjectContainer;
using BDDD.ObjectContainers.Unity;
using BDDD.Repository;
using BDDD.Repository.NHibernate;
using DemoProject.Application;
using DemoProject.Domain.Model;
using DemoProject.Domain.Repositories;
using DemoProject.Domain.Repository;
using DemoProject.Domain.Repository.FluentAutoMap;
using DemoProject.IApplication;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Practices.Unity;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DemoProject.WebMVC
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static Configuration nhibernateCfg;
        private static App application;

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}/{id}", // 带有参数的 URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();


            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            InitAppRuntime();
        }

        protected static void InitAppRuntime()
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

        private static Configuration GetNHibernateConfig()
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
                                    .Mappings(m => m.AutoMappings.Add(CreateAutomappings()))
                                    .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "web"))
                                    .BuildConfiguration();

            return nhibernateCfg;
        }

        private static AutoPersistenceModel CreateAutomappings()
        {
            // This is the actual automapping - use AutoMap to start automapping,
            // then pick one of the static methods to specify what to map (in this case
            // all the classes in the assembly that contains Employee), and then either
            // use the Setup and Where methods to restrict that behaviour, or (preferably)
            // supply a configuration instance of your definition to control the automapper.
            return AutoMap.AssemblyOf<User>()
                .Where(o => o.Namespace != null && o.Namespace.EndsWith("DemoProject.Domain.Model"))
                .Conventions.Add<CustomClassNameConvention>()
                .Conventions.Add<CustomPropertyConvention>()
                .Conventions.Add<CustomPrimaryKeyConvention>()
                .Conventions.Add<CustomCollectionConvention>()
                .Conventions.Add<CustomReferenceConvention>()
                .Conventions.Add<CustomManyToManyConvention>();
        }

    }
}