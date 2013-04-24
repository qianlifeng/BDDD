using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
