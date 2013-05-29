namespace BDDD.Events
{
    public interface IDomainEventHandler<TDomainEvent> : IEventHandler<TDomainEvent>
        where TDomainEvent : IDomainEvent
    {
    }
}