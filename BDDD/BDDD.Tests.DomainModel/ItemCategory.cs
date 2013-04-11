using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Tests.DomainModel
{
    public class ItemCategory : IAggregateRoot<Guid>
    {
        public virtual string CategoryName { get; set; }

        public virtual Guid ID
        {
            get;
            set;
        }

  
    }
}
