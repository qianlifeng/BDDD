using System.Collections.Generic;
using BDDD.Events;

namespace BDDD
{
    /// <summary>
    ///     具有溯源能力的聚合根
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface ISourcedAggregateRoot<TKey> : IAggregateRoot<TKey>
    {
        IEnumerable<IDomainEvent<TKey>> UncommittedEvents { get; }
        long Version { get; }
        long Branch { get; }
        void BuildFromHistory(IEnumerable<IDomainEvent<TKey>> historicalEvents);
    }
}