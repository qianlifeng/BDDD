using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDD.Application;
using BDDD.ObjectContainer;
using BDDD.Repository;

namespace BDDD.Commands
{
    /// <summary>
    /// 命令处理器基类，每个命令只对应一个处理器
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand>
    {
        protected virtual IDomainRepository DomainRepository
        {
            get { return ServiceLocator.Instance.GetService<IDomainRepository>(); }
        }

        public abstract bool Handle(TCommand message);
    }
}
