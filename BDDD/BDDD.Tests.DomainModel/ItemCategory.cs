using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Tests.DomainModel
{
    public class ItemCategory : IEntity
    {
        private Guid id;
        public virtual string CategoryName { get; set; }

        public ItemCategory()
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
                id = new Guid();
            }
        }

        public virtual bool Equals(IEntity other)
        {
            throw new NotImplementedException();
        }
    }
}
