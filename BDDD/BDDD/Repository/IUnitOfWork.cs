using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Repository
{
    /// <summary>
    /// 实现此接口的类会维护一个列表，该列表中包含了在一次事物中所有受到
    /// 变更的聚合根。通过commit方法将这些影响一次性提交到数据库
    /// 
    /// Represents that the implemented classes will maintain a list of objects
    /// affected by a business transaction and coordinate the writing out of changes
    /// and the resolution of concurrency problems. Unit of Work is an object-relational
    /// behavioral pattern which was described in Martin Fowler's book, Patterns of
    /// Enterprise Application Architecture. For more information about Unit of Work
    /// architectural pattern, please refer to http://martinfowler.com/eaaCatalog/unitOfWork.html.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 工作单元中的任务是否已经提交
        /// </summary>
        bool Committed { get; }
        /// <summary>
        /// 提交工作单元中的事物
        /// </summary>
        void Commit();
        /// <summary>
        /// 撤销工作单元中的事物
        /// </summary>
        void Rollback();
    }
}
