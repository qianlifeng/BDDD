using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using BDDD.Repository.NHibernate.Properties;
using BDDD.Specification;

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
            session.Delete(aggregateRoot);
        }

        protected override void DoUpdate(TAggregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
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

        protected override IEnumerable<TAggregateRoot> DoGetAll(Specification.ISpecification<TAggregateRoot> specification, int pageNumber, int pageSize, System.Linq.Expressions.Expression<Func<TAggregateRoot, object>> sortPredicate, params System.Linq.Expressions.Expression<Func<TAggregateRoot, object>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<TAggregateRoot> DoGetAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
