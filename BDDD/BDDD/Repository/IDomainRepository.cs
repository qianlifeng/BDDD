using System;

namespace BDDD.Repository
{
    public interface IDomainRepository : IUnitOfWork, IDisposable
    {
        TAggregateRoot Get<TAggregateRoot, Tkey>(Guid id) where TAggregateRoot : class, ISourcedAggregateRoot<Tkey>;

        void Save<TAggregateRoot, Tkey>(TAggregateRoot aggregateRoot)
            where TAggregateRoot : class, ISourcedAggregateRoot<Tkey>;
    }
}