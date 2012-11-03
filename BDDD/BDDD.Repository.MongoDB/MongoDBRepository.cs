using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Repository.MongoDB
{
    public class MongoDBRepository<TAggregateRoot> : Repository<TAggregateRoot> where TAggregateRoot : class,IAggregateRoot
    {
        protected override void DoAdd(TAggregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
        }

        protected override bool DoExists(Specification.ISpecification<TAggregateRoot> specification)
        {
            throw new NotImplementedException();
        }

        protected override void DoRemove(TAggregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
        }

        protected override void DoUpdate(TAggregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
        }

        protected override TAggregateRoot DoGetByKey(object key)
        {
            throw new NotImplementedException();
        }

        protected override TAggregateRoot DoGetSignal(Specification.ISpecification<TAggregateRoot> specification)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<TAggregateRoot> DoGetAll()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<TAggregateRoot> DoGetAll(Specification.ISpecification<TAggregateRoot> specification)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<TAggregateRoot> DoGetAll(Specification.ISpecification<TAggregateRoot> specification, int pageNumber, int pageSize, System.Linq.Expressions.Expression<Func<TAggregateRoot, object>> sortPredicate, params System.Linq.Expressions.Expression<Func<TAggregateRoot, object>>[] eagerLoadingProperties)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<TAggregateRoot> DoGetAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
