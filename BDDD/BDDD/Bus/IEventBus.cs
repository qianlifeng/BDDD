using BDDD.Events;

namespace BDDD.Bus
{
    public interface IEventBus<TKey> : IBus<IEvent<TKey>>
    {
    }
}