using System;

namespace BDDD.Events
{
    public interface IEvent : IEntity
    {
        DateTime Timestamp { get; set; }
        string AssemblyQualifiedEventType { get; set; }
    }
}