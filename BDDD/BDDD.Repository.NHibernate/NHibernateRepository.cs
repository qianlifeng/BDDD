using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using BDDD.Repository.NHibernate.Properties;
using BDDD.Specification;
using System.Linq.Expressions;

namespace BDDD.Repository.NHibernate
{
    public class NHibernateRepository<TAggregateRoot> : Repository<TAggregateRoot> where TAggregateRoot : class,IAggregateRoot
    {
        private readonly ISession session = null;

        public NHibernateRepository(IRepositoryContext context)
            : base(context)
        {
            if (context is INHibernateContext)
                session = (context as INHibernateContext).Session;
            else
                throw new RepositoryException(Resource.EX_INVALID_CONTEXT_TYPE);
        }

        #region 实现Repository中的抽象方法

        protected override void DoAdd(TAggregateRoot aggregateRoot)
        {
            Context.RegisterNew(aggregateRoot);
        }

        protected override bool DoExists(ISpecification<TAggregateRoot> specification)
        {
            return DoGetSignal(specification) != null;
        }

        protected override void DoRemove(TAggregateRoot aggregateRoot)
        {
            Context.RegisterDeleted(aggregateRoot);
        }

        protected override void DoUpdate(TAggregateRoot aggregateRoot)
        {
            Context.RegisterModified(aggregateRoot);
        }

        protected override TAggregateRoot DoGetByKey(object key)
        {
            return session.Get<TAggregateRoot>(key);
        }

        protected override TAggregateRoot DoGetSignal(ISpecification<TAggregateRoot> specification)
        {
            return session.Query<TAggregateRoot>().Where(specification.GetExpression()).FirstOrDefault();
        }

        protected override IEnumerable<TAggregateRoot> DoGetAll()
        {
            return session.QueryOver<TAggregateRoot>().List();
        }

        protected override IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification)
        {
            return session.Query<TAggregateRoot>().Where(specification.GetExpression());
        }

        protected override IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification, int pageNumber, int pageSize, Expression<Func<TAggregateRoot, object>> sortPredicate,SortOrder sortOrder, params System.Linq.Expressions.Expression<Func<TAggregateRoot, object>>[] eagerLoadingProperties)
        {
            if (pageNumber <= 0)
                throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "PageNumber必须大于0");
            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException("pageSize", pageSize, "pageSize必须大于0");
            var query = this.session.Query<TAggregateRoot>().Where(specification.GetExpression());
            foreach (var eager in eagerLoadingProperties)
            {
                query = query.Fetch(eager);
            }
            int skip = (pageNumber - 1) * pageSize;
            int take = pageSize;
            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    if (sortPredicate != null)
                        return query.OrderBy(sortPredicate).Skip(skip).Take(take).ToList();
                    break;
                case SortOrder.Descending:
                    if (sortPredicate != null)
                        return query.OrderByDescending(sortPredicate).Skip(skip).Take(take).ToList();
                    break;
                default:
                    break;
            }
            return query.Skip(skip).Take(take).ToList();
        }

        protected override IEnumerable<TAggregateRoot> DoGetAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
