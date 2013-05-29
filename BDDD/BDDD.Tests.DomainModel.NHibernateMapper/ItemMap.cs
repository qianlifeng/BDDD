using System;
using FluentNHibernate.Mapping;

namespace BDDD.Tests.DomainModel.NHibernateMapper
{
    public class ItemMap : ClassMap<Item>
    {
        public ItemMap()
        {
            Id(m => m.ID).GeneratedBy.Guid();
            Map(m => m.ItemName);
            References(m => m.Category).Cascade.SaveUpdate();
        }
    }
}