using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Commands
{
    /// <summary>
    /// 命令对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommand<T> : IEntity<T>
    {

    }
}
