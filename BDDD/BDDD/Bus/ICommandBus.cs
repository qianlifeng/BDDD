using BDDD.Commands;

namespace BDDD.Bus
{
    public interface ICommandBus : IBus<ICommand>
    {
    }
}