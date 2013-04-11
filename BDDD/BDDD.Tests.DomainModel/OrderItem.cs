using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Tests.DomainModel
{
    public class OrderItem : IEntity<Guid>
    {
        public virtual int Quantity { get; set; }
        public virtual Item Item { get; set; }

        public virtual Guid ID { get; set; }

    }
}
