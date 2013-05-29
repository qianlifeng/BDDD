using System;
using FluentNHibernate.Mapping;

namespace BDDD.Tests.DomainModel.NHibernateMapper
{
    public class ItemCategoryMap : ClassMap<ItemCategory>
    {
        public ItemCategoryMap()
        {
            Id(m => m.ID).GeneratedBy.Guid();
            Map(m => m.CategoryName);
        }
    }
}