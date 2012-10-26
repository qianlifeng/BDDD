using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BDDD.Specification;

namespace BDDD.Repository
{
    /// <summary>
    /// 实现此接口的类是一个聚合根仓储
    /// </summary>
    /// <typeparam name="TAggregateRoot">聚合根</typeparam>
    public interface IRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
    {
        /// <summary>
        /// 获得当前仓储所处的仓储上下文对象
        /// </summary>     
        IRepositoryContext Context { get; }

        /// <summary>
        /// 将一个聚合根加入到仓储中
        /// </summary>
        /// <param name="aggregateRoot">要加入仓储的聚合根</param>
        void Add(TAggregateRoot aggregateRoot);

        /// <summary>
        /// Checkes whether the aggregate root, which matches the given specification, exists in the repository.
        /// </summary>
        /// <param name="specification">The specification with which the aggregate root should match.</param>
        /// <returns>True if the aggregate root exists, otherwise false.</returns>
        bool Exists(ISpecification<TAggregateRoot> specification);

        /// <summary>
        /// 移除仓储中的聚合根
        /// </summary>
        /// <param name="aggregateRoot">要移除的聚合根</param>
        void Remove(TAggregateRoot aggregateRoot);

        /// <summary>
        /// 更新仓储中的聚合根
        /// </summary>
        /// <param name="aggregateRoot">聚合根</param>
        void Update(TAggregateRoot aggregateRoot);

        /// <summary>
        /// 根据主键得到一个聚合根对象
        /// </summary>
        /// <param name="key">聚合根的主键</param>
        /// <returns>聚合根</returns>
        TAggregateRoot GetByKey(object key);

        TAggregateRoot GetSignal(ISpecification<TAggregateRoot> specification);

        #region GetAll

        /// <summary>
        /// 得到当前对象仓储中的所有聚合根对象
        /// </summary>
        /// <returns>所有的聚合根</returns>
        IEnumerable<TAggregateRoot> GetAll();

        /// <summary>
        /// 得到当前对象仓储中的所有聚合根对象
        /// </summary>
        /// <param name="specification">要筛选的规约</param>
        /// <returns></returns>
        IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification);

        /// <summary>
        /// 得到当前对象仓储中的所有聚合根对象
        /// </summary>
        /// <param name="specification">要筛选的规约</param>
        /// <param name="pageNumber">当前页</param>
        /// <param name="pageSize">每页页数</param>
        /// <param name="sortPredicate">排序属性</param>
        /// <param name="eagerLoadingProperties">需要提前加载的属性</param>
        /// <returns></returns>
        IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, int pageNumber, int pageSize, Expression<Func<TAggregateRoot, object>> sortPredicate, params Expression<Func<TAggregateRoot, object>>[] eagerLoadingProperties);

        /// <summary>
        ///  得到当前对象仓储中的所有聚合根对象
        /// </summary>
        /// <param name="pageNumber">页号</param>
        /// <param name="pageSize">每页大小</param>
        /// <returns>当前页的聚合根</returns>
        IEnumerable<TAggregateRoot> GetAll(int pageNumber, int pageSize);

        #endregion
    }
}
