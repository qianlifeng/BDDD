using NHibernate.Cfg;

namespace BDDD.Repository.NHibernate
{
    /// <summary>
    ///     实现此接口的类能提供不同的NHibernate配置方式，比如Fluent Nhibernate
    /// </summary>
    public interface INHibernateConfiguration
    {
        Configuration GetNHibernateConfiguration();
    }
}