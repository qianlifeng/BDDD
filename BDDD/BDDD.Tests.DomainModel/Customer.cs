using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Tests.DomainModel
{
    public class Customer : IAggregateRoot
    {
        private Guid id;

        public Customer() { }

        public Customer(string name, int age)
        {
            Name = name;
            Age = age;
            id = Guid.NewGuid();
        }

        public virtual string Name { get;  set; }

        public virtual int Age { get;  set; }

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
