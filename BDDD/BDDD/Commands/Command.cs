using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Commands
{
    [Serializable]
    public abstract class Command<T> : ICommand<T>
    {

        public Command() { }

        public Command(T id)
        {
            ID = id;
        }

        public virtual T ID
        {
            get;
            set;
        }
    }
}
