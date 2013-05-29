using System;

namespace BDDD.Commands
{
    [Serializable]
    public abstract class Command : ICommand
    {
        protected Command()
        {
        }

        protected Command(Guid id)
        {
            ID = id;
        }

        public virtual Guid ID { get; set; }
    }
}