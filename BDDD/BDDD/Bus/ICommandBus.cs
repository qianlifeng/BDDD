using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDD.Commands;

namespace BDDD.Bus
{
    public interface ICommandBus<TKey>: IBus<ICommand<TKey>>
    {
    }
}
