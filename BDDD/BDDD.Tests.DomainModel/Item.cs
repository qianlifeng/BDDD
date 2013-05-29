using System;

namespace BDDD.Tests.DomainModel
{
    public class Item : IEntity<Guid>
    {
        public virtual string ItemName { get; set; }
        public virtual ItemCategory Category { get; set; }

        public virtual Guid ID { get; set; }
    }
}