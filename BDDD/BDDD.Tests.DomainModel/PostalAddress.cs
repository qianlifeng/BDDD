using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Tests.DomainModel
{
    public class PostalAddress:IEntity
    {
        private Guid id;

        public virtual string City { get; set; }
        public virtual string Street { get; set; }
        public virtual string Phone { get; set; }

        public PostalAddress()
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