using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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
        /// 根据主键得到一个聚合根对象
        /// </summary>
        /// <param name="key">聚合根的主键</param>
        /// <returns>聚合根</returns>
        TAggregateRoot GetByKey(object key);

        /// <summary>
        /// 得到当前对象仓储中的所有聚合根对象
        /// </summary>
        /// <returns>所有的聚合根</returns>
        IEnumerable<TAggregateRoot> GetAll();
        
        /// <summary>
        ///  得到当前对象仓储中的所有聚合根对象
        /// </summary>
        /// <param name="pageNumber">页号</param>
        /// <param name="pageSize">每页大小</param>
        /// <returns>当前页的聚合根</returns>
        IEnumerable<TAggregateRoot> GetAll(int pageNumber, int pageSize);

        /// <summary>
        /// Gets all the aggregate roots from repository.
        /// </summary>
        /// <param name="sortPredicate">The sort predicate which is used for sorting.</param>
        /// <param name="sortOrder">The <see cref="Apworks.Storage.SortOrder"/> enumeration which specifies the sort order.</param>
        /// <returns>All the aggregate roots got from the repository, with the aggregate roots being sorted by
        /// using the provided sort predicate and the sort order.</returns>
        IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, object>> sortPredicate, SortOrder sortOrder);

        /// <summary>
        /// Gets all the aggregate roots from repository.
        /// </summary>
        /// <param name="sortPredicate">The sort predicate which is used for sorting.</param>
        /// <param name="sortOrder">The <see cref="Apworks.Storage.SortOrder"/> enumeration which specifies the sort order.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The number of objects per page.</param>
        /// <returns>All the aggregate roots got from the repository for the specified page, with the aggregate roots being sorted by
        /// using the provided sort predicate and the sort order.</returns>
        IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, bool>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize);
        /// <summary>
        /// Gets all the aggregate roots from repository.
        /// </summary>
        /// <param name="eagerLoadingProperties">The properties for the aggregated objects that need to be loaded.</param>
        /// <returns>The aggregate roots.</returns>
        IEnumerable<TAggregateRoot> GetAll(params Expression<Func<TAggregateRoot, bool>>[] eagerLoadingProperties);
        
        /// <summary>
        /// Gets all the aggregate roots from repository.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The number of objects per page.</param>
        /// <param name="eagerLoadingProperties">The properties for the aggregated objects that need to be loaded.</param>
        /// <returns>The aggregate roots.</returns>
        IEnumerable<TAggregateRoot> GetAll(int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, bool>>[] eagerLoadingProperties);

        /// <summary>
        /// Gets all the aggregate roots from repository.
        /// </summary>
        /// <param name="sortPredicate">The sort predicate which is used for sorting.</param>
        /// <param name="sortOrder">The <see cref="Apworks.Storage.SortOrder"/> enumeration which specifies the sort order.</param>
        /// <param name="eagerLoadingProperties">The properties for the aggregated objects that need to be loaded.</param>
        /// <returns>The aggregate roots.</returns>
        IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, bool>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, bool>>[] eagerLoadingProperties);
       
        /// <summary>
        /// Gets all the aggregate roots from repository.
        /// </summary>
        /// <param name="sortPredicate">The sort predicate which is used for sorting.</param>
        /// <param name="sortOrder">The <see cref="Apworks.Storage.SortOrder"/> enumeration which specifies the sort order.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The number of objects per page.</param>
        /// <param name="eagerLoadingProperties">The properties for the aggregated objects that need to be loaded.</param>
        /// <returns>The aggregated roots.</returns>
        IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, bool>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, bool>>[] eagerLoadingProperties);
        /// <summary>
        /// Finds all the aggregate roots from repository.
        /// </summary>
        /// <returns>The aggregate roots.</returns>
        IEnumerable<TAggregateRoot> FindAll();
        /// <summary>
        /// Finds all the aggregate roots from repository.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The number of objects per page.</param>
        /// <returns>The aggregate roots.</returns>
        IEnumerable<TAggregateRoot> FindAll(int pageNumber, int pageSize);
        /// <summary>
        /// Finds all the aggregate roots from repository.
        /// </summary>
        /// <param name="sortPredicate">The sort predicate which is used for sorting.</param>
        /// <param name="sortOrder">The <see cref="Apworks.Storage.SortOrder"/> enumeration which specifies the sort order.</param>
        /// <returns>The aggregate roots.</returns>
        IEnumerable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> sortPredicate, SortOrder sortOrder);
        /// <summary>
        /// Finds all the aggregate roots from repository.
        /// </summary>
        /// <param name="sortPredicate">The sort predicate which is used for sorting.</param>
        /// <param name="sortOrder">The <see cref="Apworks.Storage.SortOrder"/> enumeration which specifies the sort order.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The number of objects per page.</param>
        /// <returns>The aggregate roots.</returns>
        IEnumerable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize);
        /// <summary>
        /// Finds all the aggregate roots from repository.
        /// </summary>
        /// <param name="eagerLoadingProperties">The properties for the aggregated objects that need to be loaded.</param>
        /// <returns>The aggregate root.</returns>
        IEnumerable<TAggregateRoot> FindAll(params Expression<Func<TAggregateRoot, bool>>[] eagerLoadingProperties);
        /// <summary>
        /// Finds all the aggregate roots from repository.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The number of objects per page.</param>
        /// <param name="eagerLoadingProperties">The properties for the aggregated objects that need to be loaded.</param>
        /// <returns>The aggregate root.</returns>
        IEnumerable<TAggregateRoot> FindAll(int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, bool>>[] eagerLoadingProperties);
        /// <summary>
        /// Finds all the aggregate roots from repository.
        /// </summary>
        /// <param name="sortPredicate">The sort predicate which is used for sorting.</param>
        /// <param name="sortOrder">The <see cref="Apworks.Storage.SortOrder"/> enumeration which specifies the sort order.</param>
        /// <param name="eagerLoadingProperties">The properties for the aggregated objects that need to be loaded.</param>
        /// <returns>The aggregate root.</returns>
        IEnumerable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, bool>>[] eagerLoadingProperties);
        /// <summary>
        /// Finds all the aggregate roots from repository.
        /// </summary>
        /// <param name="sortPredicate">The sort predicate which is used for sorting.</param>
        /// <param name="sortOrder">The <see cref="Apworks.Storage.SortOrder"/> enumeration which specifies the sort order.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The number of objects per page.</param>
        /// <param name="eagerLoadingProperties">The properties for the aggregated objects that need to be loaded.</param>
        /// <returns>The aggregate root.</returns>
        IEnumerable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, bool>>[] eagerLoadingProperties);
        
        /// <summary>
        /// Checkes whether the aggregate root, which matches the given specification, exists in the repository.
        /// </summary>
        /// <param name="specification">The specification with which the aggregate root should match.</param>
        /// <returns>True if the aggregate root exists, otherwise false.</returns>
        bool Exists(Expression<Func<TAggregateRoot,bool>> specification);
        
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
    }
}
