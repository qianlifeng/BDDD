using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace BDDD.Tests.DomainModel.NHibernateMapper
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(m => m.ID).GeneratedBy.Guid();
            Map(m => m.OrderName);
            Map(m => m.CreatedDate);
            References(m => m.Customer).Cascade.All();
            HasMany(m => m.Items).Cascade.SaveUpdate();
            Component(m => m.postalAddress);
        }
    }
}
