using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD
{
    public interface IHandler<T>
    {
        bool Handle(T message);
    }
}
