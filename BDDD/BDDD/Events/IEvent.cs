using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Events
{
    public interface IEvent<TKey> : IEntity<TKey>
    {
        DateTime Timestamp { get; set; }
        string AssemblyQualifiedEventType { get; set; }
    }
}
