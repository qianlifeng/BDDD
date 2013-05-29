using System;
using FluentNHibernate.Mapping;

namespace BDDD.Tests.DomainModel.NHibernateMapper
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(m => m.ID).GeneratedBy.Guid();
            Map(m => m.Name);
            Map(m => m.Age);
            HasMany(m => m.PostalAddresses).Cascade.SaveUpdate();
        }
    }
}