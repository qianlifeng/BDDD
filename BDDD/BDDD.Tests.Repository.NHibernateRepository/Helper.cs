using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using BDDD.Tests.DomainModel;
using FluentNHibernate.Automapping;

namespace BDDD.Tests.Repository.NHibernateRepository
{
    public class Helper
    {
        public const string NHIBERNATE_DB_CONNECTSTRING = @"Server=localhost;Database=BDDD_NHibernate;Integrated Security=SSPI;";

        public static NHibernate.Cfg.Configuration SetupNHibernateDatabase()
        {
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
            return nhibernateCfg;
        }
    }
}
