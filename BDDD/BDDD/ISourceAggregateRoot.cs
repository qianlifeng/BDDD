using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDD.Events;

namespace BDDD
{
    /// <summary>
    /// 具有溯源能力的聚合根
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface ISourcedAggregateRoot<TKey> : IAggregateRoot<TKey>
    {
        void BuildFromHistory(IEnumerable<IDomainEvent<TKey>> historicalEvents);
        IEnumerable<IDomainEvent<TKey>> UncommittedEvents { get; }
        long Version { get; }
        long Branch { get; }
    }
}
