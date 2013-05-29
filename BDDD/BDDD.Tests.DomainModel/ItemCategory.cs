using System;

namespace BDDD.Tests.DomainModel
{
    public class ItemCategory : IAggregateRoot
    {
        public virtual string CategoryName { get; set; }

        public virtual Guid ID { get; set; }
    }
}