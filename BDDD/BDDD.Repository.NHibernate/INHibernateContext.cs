using NHibernate;

namespace BDDD.Repository.NHibernate
{
    /// <summary>
    ///     Represents that the implemented classes are NHibernate Context
    /// </summary>
    internal interface INHibernateContext : IRepositoryContext
    {
        /// <summary>
        ///     获得NHibernate的session实例，此示例是单例的
        /// </summary>
        ISession Session { get; }
    }
}