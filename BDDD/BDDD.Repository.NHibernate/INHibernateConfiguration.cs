using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;

namespace BDDD.Repository.NHibernate
{
    public interface INHibernateConfiguration
    {
        Configuration GetNHibernateConfiguration();
    }
}
