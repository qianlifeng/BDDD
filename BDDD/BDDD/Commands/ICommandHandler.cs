using BDDD.Events;

namespace BDDD.Commands
{
    public interface ICommandHandler<TCommand> : IHandler<TCommand>
    {
    }
}