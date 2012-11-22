using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            HasMany<PostalAddress>(m => m.PostalAddresses).Cascade.SaveUpdate();
        }
    }
}
