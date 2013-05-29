namespace BDDD.Events
{
    public interface IDomainEvent : IEvent
    {
        IEntity Source { get; set; }
        long Version { get; set; }
        long Branch { get; set; }
    }
}