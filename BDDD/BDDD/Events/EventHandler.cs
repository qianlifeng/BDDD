using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Events
{
    public abstract class EventHandler<TEvent,TKey> : IEventHandler<TEvent,TKey>
        where TEvent:IEvent<TKey>
    {
        public  abstract bool Handle(TEvent message);
    }
}
