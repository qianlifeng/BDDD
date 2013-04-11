using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Repository
{
    /// <summary>
    /// 继承此接口的类具有管理仓储的能力
    /// </summary>
   public interface IRepositoryContext : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// Gets the unique-identifier of the repository context.
        /// </summary>
        Guid ID { get; }

        /// <summary>
        /// 向仓储环境中添加一个新的对象，此对象不会被立即提交到数据库
        /// 而是等待Commit()动作一起提交到数据库。
        /// </summary>
        void RegisterNew(object obj);

        /// <summary>
        /// 向仓储环境中添加一个需要修改的对象，此对象不会被立即提交到数据库
        /// 而是等待Commit()动作一起提交到数据库。
        /// </summary>
        void RegisterModified(object obj);

        /// <summary>
        /// 向仓储环境中删除一个对象，此对象不会被立即提交到数据库
        /// 而是等待Commit()动作一起提交到数据库。
        /// </summary>
        void RegisterDeleted(object obj);

        /// <summary>
        /// 根据给定的聚合根，从当前的RepositoryContext中得到Repository对象
        /// </summary>
        IRepository<TAggregateRoot> GetRepository<TAggregateRoot>() where TAggregateRoot : class;
    }
}
