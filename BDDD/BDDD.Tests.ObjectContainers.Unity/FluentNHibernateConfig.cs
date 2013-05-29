using BDDD.Repository.NHibernate;
using BDDD.Tests.DomainModel.NHibernateMapper;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate.Cfg;

namespace BDDD.Tests.ObjectContainers.Unity
{
    public class FluentNHibernateConfiguration : INHibernateConfiguration
    {
        public Configuration GetNHibernateConfiguration()
        {
            return Fluently.Configure()
                           .Database(MsSqlConfiguration.MsSql2008
                                                       .ConnectionString(s => s.Server("localhost")
                                                                               .Database("BDDD_NHibernate")
                                                                               .TrustedConnection()))
                           .Mappings(m => m.FluentMappings.AddFromAssembly(typeof (CustomerMap).Assembly)
                                           .Conventions.Add(ForeignKey.EndsWith("Id")))
                           .BuildConfiguration();
        }
    }
}