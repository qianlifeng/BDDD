using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace BDDD.Repository.NHibernate
{
    /// <summary>
    /// Represents that the implemented classes are NHibernate Context
    /// </summary>
    internal interface INHibernateContext : IRepositoryContext
    {
        /// <summary>
        /// Gets the NHibernate Session instance.
        /// </summary>
        ISession Session { get; }
    }
}
