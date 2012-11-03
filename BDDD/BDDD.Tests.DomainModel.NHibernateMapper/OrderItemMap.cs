using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace BDDD.Tests.DomainModel.NHibernateMapper
{
    public class OrderItemMap:ClassMap<OrderItem>
    {
        public OrderItemMap()
        {
            Id(m => m.ID).GeneratedBy.Guid();
            Map(m => m.Quantity);
            References(m => m.Item).Cascade.All();
        }
    }
}
