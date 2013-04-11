using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Tests.DomainModel
{
    public class PostalAddress:IEntity<Guid>
    {
        public virtual string City { get; set; }
        public virtual string Street { get; set; }
        public virtual string Phone { get; set; }

        public virtual Guid ID { get; set; }

    }
}