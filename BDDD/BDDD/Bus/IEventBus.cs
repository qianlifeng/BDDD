using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDD.Commands;
using BDDD.Events;

namespace BDDD.Bus
{
    public interface IEventBus<TKey>: IBus<IEvent<TKey>>
    {
    }
}
