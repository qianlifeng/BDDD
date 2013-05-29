using BDDD.Events;

namespace BDDD.Bus
{
    public interface IEventBus : IBus<IEvent>
    {
    }
}