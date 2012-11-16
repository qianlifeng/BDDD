using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using BDDD.Tests.DomainModel.NHibernateMapper;
using FluentNHibernate.Conventions.Helpers;
using BDDD.Repository.NHibernate;

namespace BDDD.Tests.ObjectContainers.Unity
{
    public class FluentNHibernateConfiguration : INHibernateConfiguration
    {
        public Configuration GetNHibernateConfiguration()
        {
            return Fluently.Configure()
                 .Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2008
                       .ConnectionString(s => s.Server("localhost")
                       .Database("BDDD_NHibernate")
                       .TrustedConnection()))
                 .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(CustomerMap).Assembly)
                       .Conventions.Add(ForeignKey.EndsWith("Id")))
                 .BuildConfiguration();
        }
    }
}
