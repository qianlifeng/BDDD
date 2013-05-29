using FluentNHibernate.Mapping;

namespace BDDD.Tests.DomainModel.NHibernateMapper
{
    public class OrderItemMap : ClassMap<OrderItem>
    {
        public OrderItemMap()
        {
            Id(m => m.ID).GeneratedBy.Guid();
            Map(m => m.Quantity);
            References(m => m.Item).Cascade.All();
        }
    }
}