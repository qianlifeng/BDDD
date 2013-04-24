using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Events
{
    public interface IDomainEventHandler<TDomainEvent, TKey> : IEventHandler<TDomainEvent, TKey>
        where TDomainEvent : IDomainEvent<TKey>
    {
    }
}
