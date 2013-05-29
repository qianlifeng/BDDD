using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BDDD.Specification;

namespace BDDD.Repository.MongoDB
{
    public class MongoDBRepository<TAggregateRoot> : Repository<TAggregateRoot> where TAggregateRoot : class
    {
        private IMongoDBContext context;

        public MongoDBRepository(IMongoDBContext context) : base(context)
        {
            this.context = context;
        }

        protected override void DoAdd(TAggregateRoot aggregateRoot)
        {
            throw new NotImplementedException();
        }

        protected override bool DoExists(ISpecification<TAggregateRoot> specification)
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

        protected override TAggregateRoot DoGetSignal(ISpecification<TAggregateRoot> specification)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<TAggregateRoot> DoGetAll()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<TAggregateRoot> DoGetAll(ISpecification<TAggregateRoot> specification,
                                                                int pageNumber, int pageSize,
                                                                Expression<Func<TAggregateRoot, object>> sortPredicate,
                                                                SortOrder sortOrder)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<TAggregateRoot> DoGetAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<TAggregateRoot> DoGetAll(int pageNumber, int pageSize,
                                                                Expression<Func<TAggregateRoot, object>> sortPredicate,
                                                                SortOrder sortOrder)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<TAggregateRoot> DoGetAll(Expression<Func<TAggregateRoot, bool>> specification)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<TAggregateRoot> DoGetAll(Expression<Func<TAggregateRoot, bool>> specification,
                                                                int pageNumber, int pageSize,
                                                                Expression<Func<TAggregateRoot, object>> sortPredicate,
                                                                SortOrder sortOrder)
        {
            throw new NotImplementedException();
        }
    }
}