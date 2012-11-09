using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using BDDD.Tests.DomainModel;
using FluentNHibernate.Automapping;
using BDDD.Tests.DomainModel.NHibernateMapper;
using FluentNHibernate.Conventions.Helpers;

namespace BDDD.Tests.Repository.NHibernateRepository
{
    public class Helper
    {
        public const string NHIBERNATE_DB_CONNECTSTRING = @"Server=localhost;Database=BDDD_NHibernate;Integrated Security=SSPI;";

        static NHibernate.Cfg.Configuration nhibernateCfg;

        public static NHibernate.Cfg.Configuration SetupNHibernateDatabase()
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

            ResetDB();
            return nhibernateCfg;
        }

        public static void ResetDB()
        {
            if (nhibernateCfg != null)
            {
                NHibernate.Tool.hbm2ddl.SchemaExport schemaExport = new NHibernate.Tool.hbm2ddl.SchemaExport(nhibernateCfg);
                schemaExport.Execute(false, true, false);
            }
        }

    }
}
