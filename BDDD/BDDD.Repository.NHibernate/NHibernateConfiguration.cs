using NHibernate.Cfg;

namespace BDDD.Repository.NHibernate
{
    public class NHibernateConfiguration : INHibernateConfiguration
    {
        private Configuration config;

        public NHibernateConfiguration()
        {
            config = new Configuration().Configure();
        }

        public NHibernateConfiguration(string fileName)
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