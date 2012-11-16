using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;

namespace BDDD.Repository.NHibernate
{
    public class NHibernateConfiguration : INHibernateConfiguration
    {
        private Configuration config;

        public NHibernateConfiguration()
            : base()
        {
            config = new Configuration().Configure();
        }

        public NHibernateConfiguration(string fileName)
            : base()
        {
            config = new Configuration().Configure(fileName);
        }

        public NHibernateConfiguration(Configuration config)
        {
            this.config = config;
        }

        public Configuration GetNHibernateConfiguration()
        {
            return config;
        }
    }
}
