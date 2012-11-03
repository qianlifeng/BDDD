using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Tests.DomainModel
{
    public class Order : IAggregateRoot
    {
        public virtual string OrderName { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual IList<OrderItem> Items { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual PostalAddress postalAddress { get; set; }

        public virtual Guid ID { get; set; }

        public virtual bool Equals(IEntity other)
        {
            throw new NotImplementedException();
        }
    }
}
