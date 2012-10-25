using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Repository
{
    /// <summary>
    /// Represents that the implemented classes are repository transaction contexts.
    /// </summary>
   public interface IRepositoryContext : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// Gets the unique-identifier of the repository context.
        /// </summary>
        Guid ID { get; }
        /// <summary>
        /// Registers a new object to the repository context.
        /// </summary>
        /// <param name="obj">The object to be registered.</param>
        void RegisterNew(object obj);
        /// <summary>
        /// Registers a modified object to the repository context.
        /// </summary>
        /// <param name="obj">The object to be registered.</param>
        void RegisterModified(object obj);
        /// <summary>
        /// Registers a deleted object to the repository context.
        /// </summary>
        /// <param name="obj">The object to be registered.</param>
        void RegisterDeleted(object obj);
        /// <summary>
        /// Gets the repository instance from the transaction context according
        /// to the given aggregate root type.
        /// </summary>
        /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
        /// <returns>The repository instance for the specified aggregate root type.</returns>
        IRepository<TAggregateRoot> GetRepository<TAggregateRoot>() where TAggregateRoot : class, IAggregateRoot;
    }
}
