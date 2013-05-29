namespace BDDD.Events
{
    public interface IDomainEventHandler<TDomainEvent, TKey> : IEventHandler<TDomainEvent, TKey>
        where TDomainEvent : IDomainEvent<TKey>
    {
    }
}