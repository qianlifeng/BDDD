using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Events
{
    public interface IDomainEvent<TKey> : IEvent<TKey>
    {
        IEntity<TKey> Source { get; set; }
        long Version { get; set; }
        long Branch { get; set; }
    }
}
