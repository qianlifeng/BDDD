using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Tests.DomainModel
{
    public class Order : IAggregateRoot
    {
        private Guid id;

        public virtual string OrderName { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual List<OrderItem> Items { get; set; }
        public virtual Customer Customer { get; set; }

        public Order()
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
