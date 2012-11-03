using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace BDDD.Tests.DomainModel.NHibernateMapper
{
    public class ItemCategoryMap:ClassMap<ItemCategory>
    {
        public ItemCategoryMap()
        {
            Id(m => m.ID).GeneratedBy.Guid();
            Map(m => m.CategoryName);
        }
    }
}
