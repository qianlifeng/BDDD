using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.ObjectContainer
{
    public interface IObjectContainer:IServiceProvider
    {
        T GetService<T>() where T : class;
    }
}
