using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Repository
{
    /// <summary>
    /// 仓储基类
    /// </summary>
    /// <typeparam name="TAgrregateRoot"></typeparam>
    public abstract class Repository<TAgrregateRoot> : IRepository<TAgrregateRoot>
        where TAgrregateRoot : class,IAggregateRoot
    {
        private readonly IRepositoryContext context;

        public Repository(IRepositoryContext context)
        {
            this.context = context;
        }

        #region IRepository 接口

        public IRepositoryContext Context
        {
            get { return context; }
        }

        public void Add(TAgrregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public TAgrregateRoot GetByKey(object key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAgrregateRoot> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAgrregateRoot> GetAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAgrregateRoot> GetAll(System.Linq.Expressions.Expression<Func<TAgrregateRoot, object>> sortPredicate, SortOrder sortOrder)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAgrregateRoot> GetAll(System.Linq.Expressions.Expression<Func<TAgrregateRoot, bool>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAgrregateRoot> GetAll(params System.Linq.Expressions.Expression<Func<TAgrregateRoot, bool>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAgrregateRoot> GetAll(int pageNumber, int pageSize, params System.Linq.Expressions.Expression<Func<TAgrregateRoot, bool>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAgrregateRoot> GetAll(System.Linq.Expressions.Expression<Func<TAgrregateRoot, bool>> sortPredicate, SortOrder sortOrder, params System.Linq.Expressions.Expression<Func<TAgrregateRoot, bool>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAgrregateRoot> GetAll(System.Linq.Expressions.Expression<Func<TAgrregateRoot, bool>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params System.Linq.Expressions.Expression<Func<TAgrregateRoot, bool>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAgrregateRoot> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAgrregateRoot> FindAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAgrregateRoot> FindAll(System.Linq.Expressions.Expression<Func<TAgrregateRoot, bool>> sortPredicate, SortOrder sortOrder)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAgrregateRoot> FindAll(System.Linq.Expressions.Expression<Func<TAgrregateRoot, bool>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAgrregateRoot> FindAll(params System.Linq.Expressions.Expression<Func<TAgrregateRoot, bool>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAgrregateRoot> FindAll(int pageNumber, int pageSize, params System.Linq.Expressions.Expression<Func<TAgrregateRoot, bool>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAgrregateRoot> FindAll(System.Linq.Expressions.Expression<Func<TAgrregateRoot, bool>> sortPredicate, SortOrder sortOrder, params System.Linq.Expressions.Expression<Func<TAgrregateRoot, bool>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TAgrregateRoot> FindAll(System.Linq.Expressions.Expression<Func<TAgrregateRoot, bool>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params System.Linq.Expressions.Expression<Func<TAgrregateRoot, bool>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        public bool Exists(System.Linq.Expressions.Expression<Func<TAgrregateRoot, bool>> specification)
        {
            throw new NotImplementedException();
        }

        public void Remove(TAgrregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public void Update(TAgrregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
