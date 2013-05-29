using BDDD.Tests.DomainModel.NHibernateMapper;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace BDDD.Tests.Repository.NHibernateRepository
{
    public class Helper
    {
        public const string NHIBERNATE_DB_CONNECTSTRING =
            @"Server=localhost;Database=BDDD_NHibernate;Integrated Security=SSPI;";

        private static Configuration nhibernateCfg;

        public static Configuration SetupNHibernateDatabase()
        {
            nhibernateCfg = Fluently.Configure()
                                    .Database(
                                        MsSqlConfiguration.MsSql2008
                                                          .ConnectionString(s => s.Server("localhost")
                                                                                  .Database("BDDD_NHibernate")
                                                                                  .TrustedConnection())
                                                          .ShowSql()
                )
                                    .Mappings(m => m.FluentMappings.AddFromAssembly(typeof (CustomerMap).Assembly)
                                                    .Conventions.Add(ForeignKey.EndsWith("Id"))
                )
                                    .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "web"))
                                    .BuildConfiguration();

            ResetDB();
            return nhibernateCfg;
        }

        public static void ResetDB()
        {
            if (nhibernateCfg != null)
            {
                var schemaExport = new SchemaExport(nhibernateCfg);
                schemaExport.Execute(false, true, false);
            }
        }
    }
}