namespace BDDD.Events
{
    public interface IEventHandler<TEvent> : IHandler<TEvent> where TEvent : IEvent
    {
    }
}