namespace BDDD.Events
{
    public interface IEventHandler<TEvent, TKey> : IHandler<TEvent> where TEvent : IEvent<TKey>
    {
    }
}