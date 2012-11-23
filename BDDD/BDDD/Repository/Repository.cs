using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDD.Specification;
using System.Linq.Expressions;

namespace BDDD.Repository
{
    /// <summary>
    /// 仓储基类
    /// </summary>
    /// <typeparam name="TAggregateRoot"></typeparam>
    public abstract class Repository<TAggregateRoot> : IRepository<TAggregateRoot>
        where TAggregateRoot : class,IAggregateRoot
    {
        private readonly IRepositoryContext context;

        public Repository(IRepositoryContext context)
        {
            this.context = context;
        }

        #region Protected Method

        //===========================
        //将所有的这些方法延迟到不同的子类中去实现
        //===========================

        protected abstract void DoAdd(TAggregateRoot aggregateRoot);
        protected abstract bool DoExists(ISpecification<TAggregateRoot> specification);
        protected abstract void DoRemove(TAggregateRoot aggregateRoot);
        protected abstract void DoUpdate(TAggregateRoot aggregateRoot);

        protected abstract TAggregateRoot DoGetByKey(object key);
        protected abstract TAggregateRoot DoGetSignal(ISpecification<TAggregateRoot> specification);
        protected abstract IEnumerable<TAggregateRoot> DoGetAll();
        protected abstract IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification);
        protected abstract IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification, int pageNumber, int pageSize, System.Linq.Expressions.Expression<Func<TAggregateRoot, object>> sortPredicate,SortOrder sortOrder);
        protected abstract IEnumerable<TAggregateRoot> DoGetAll(int pageNumber, int pageSize);

        #endregion

        #region IRepository接口

        public IRepositoryContext Context
        {
            get { return context; }
        }

        public void Add(TAggregateRoot aggregateRoot)
        {
            DoAdd(aggregateRoot);
        }

        public bool Exists(Specification.ISpecification<TAggregateRoot> specification)
        {
            return DoExists(specification);
        }

        public void Remove(TAggregateRoot aggregateRoot)
        {
            DoRemove(aggregateRoot);
        }

        public void Update(TAggregateRoot aggregateRoot)
        {
            DoUpdate(aggregateRoot);
        }

        public TAggregateRoot GetByKey(object key)
        {
            return DoGetByKey(key);
        }

        public TAggregateRoot GetSignal(ISpecification<TAggregateRoot> specification)
        {
            return DoGetSignal(specification);
        }

        public IEnumerable<TAggregateRoot> GetAll()
        {
            return DoGetAll();
        }

        public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification)
        {
            return DoGetAll(specification);
        }

        public IEnumerable<TAggregateRoot> GetAll(ISpecification<TAggregateRoot> specification, int pageNumber, int pageSize, Expression<Func<TAggregateRoot, object>> sortPredicate,SortOrder sortOrder)
        {
            return DoGetAll(specification, pageNumber, pageSize, sortPredicate, sortOrder);
        }

        public IEnumerable<TAggregateRoot> GetAll(int pageNumber, int pageSize)
        {
            return DoGetAll(pageNumber, pageSize);
        }

        #endregion



    }
}
