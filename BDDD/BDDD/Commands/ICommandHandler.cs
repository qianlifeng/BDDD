using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Commands
{
    public interface ICommandHandler<TCommand> : IHandler<TCommand>
    {

    }
}
