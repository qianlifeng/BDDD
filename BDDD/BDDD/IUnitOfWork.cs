using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD
{
    /// <summary>
    /// Represents that the implemented classes will maintain a list of objects
    /// affected by a business transaction and coordinate the writing out of changes
    /// and the resolution of concurrency problems. Unit of Work is an object-relational
    /// behavioral pattern which was described in Martin Fowler's book, Patterns of
    /// Enterprise Application Architecture. For more information about Unit of Work
    /// architectural pattern, please refer to http://martinfowler.com/eaaCatalog/unitOfWork.html.
    /// imitate from project: http://apworks.codeplex.com/
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets a <see cref="System.Boolean"/> value which indicates
        /// whether the Unit of Work was successfully committed.
        /// </summary>
        bool Committed { get; }
        /// <summary>
        /// Commits the transaction.
        /// </summary>
        void Commit();
        /// <summary>
        /// Rollback the transaction.
        /// </summary>
        void Rollback();
    }
}
