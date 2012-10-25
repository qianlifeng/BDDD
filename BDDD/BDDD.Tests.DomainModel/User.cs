using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Tests.DomainModel
{
    public class User
    {
        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual string Name { get; protected set; }

        public virtual int Age { get; protected set; }
    }
}
