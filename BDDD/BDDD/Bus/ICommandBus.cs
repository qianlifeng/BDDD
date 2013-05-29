using BDDD.Commands;

namespace BDDD.Bus
{
    public interface ICommandBus<TKey> : IBus<ICommand<TKey>>
    {
    }
}