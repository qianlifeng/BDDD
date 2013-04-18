using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Repository
{
    public interface IDomainRepository : IUnitOfWork,IDisposable
    {
        TAggregateRoot Get<TAggregateRoot,Tkey>(Guid id) where TAggregateRoot : class, ISourcedAggregateRoot<Tkey>;

        void Save<TAggregateRoot,Tkey>(TAggregateRoot aggregateRoot) where TAggregateRoot : class, ISourcedAggregateRoot<Tkey>;
    }
}
