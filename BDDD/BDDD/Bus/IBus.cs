using System;
using System.Collections.Generic;
using BDDD.Repository;

namespace BDDD.Bus
{
    public interface IBus<TMessage> : IUnitOfWork, IDisposable
    {
        void Publish(TMessage message);
        void Publish(IEnumerable<TMessage> messages);
        void Clear();
    }
}