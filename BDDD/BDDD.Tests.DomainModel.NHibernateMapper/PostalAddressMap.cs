using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace BDDD.Tests.DomainModel.NHibernateMapper
{
    public class PostalAddressMap : ClassMap<PostalAddress>
    {
        public PostalAddressMap()
        {
            Id(m => m.ID);
            Map(m => m.City);
            Map(m => m.Phone);
            Map(m => m.Street);
        }
    }

    public class PostalAddressComponentMap : ComponentMap<PostalAddress>
    {
        public PostalAddressComponentMap()
        {
            Map(m => m.City);
            Map(m => m.Phone);
            Map(m => m.Street);
        }
    }
}
