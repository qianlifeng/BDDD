using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Tests.DomainModel
{
    public class OrderItem : IEntity
    {
        private Guid id;
        public virtual string ItemName { get; set; }

        public OrderItem()
        {
            id = Guid.NewGuid();
        }

        public virtual Guid ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public virtual bool Equals(IEntity other)
        {
            throw new NotImplementedException();
        }
    }
}
