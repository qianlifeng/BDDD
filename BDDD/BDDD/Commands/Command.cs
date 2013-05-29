using System;

namespace BDDD.Commands
{
    [Serializable]
    public abstract class Command<T> : ICommand<T>
    {
        public Command()
        {
        }

        public Command(T id)
        {
            ID = id;
        }

        public virtual T ID { get; set; }
    }
}