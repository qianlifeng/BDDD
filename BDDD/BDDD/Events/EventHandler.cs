namespace BDDD.Events
{
    public abstract class EventHandler<TEvent> : IEventHandler<TEvent>
        where TEvent : IEvent
    {
        public abstract bool Handle(TEvent message);
    }
}