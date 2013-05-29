using System;

namespace BDDD.Tests.DomainModel
{
    public class OrderItem : IEntity<Guid>
    {
        public virtual int Quantity { get; set; }
        public virtual Item Item { get; set; }

        public virtual Guid ID { get; set; }
    }
}