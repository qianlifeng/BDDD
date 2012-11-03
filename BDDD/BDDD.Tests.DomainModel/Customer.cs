﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Tests.DomainModel
{
    public class Customer : IAggregateRoot
    {
        public Customer() { }

        public Customer(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual string Name { get; set; }

        public virtual int Age { get; set; }

        public virtual IList<PostalAddress> PostalAddresses { get; set; }

        public virtual Guid ID
        {
            get;
            set;
        }

        public virtual bool Equals(IEntity other)
        {
            throw new NotImplementedException();
        }
    }
}
