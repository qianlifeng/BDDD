using System;

namespace BDDD.Events
{
    public interface IEvent<TKey> : IEntity<TKey>
    {
        DateTime Timestamp { get; set; }
        string AssemblyQualifiedEventType { get; set; }
    }
}