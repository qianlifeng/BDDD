using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Events
{
    public interface IEventHandler<TEvent,TKey>:IHandler<TEvent> where TEvent : IEvent<TKey>
    {
    }
}
