using System;
using System.Collections.Generic;
using BDDD;

namespace DemoProject.Domain.Model
{
    public class Role : IAggregateRoot, IEquatable<Role> 
    {
        public virtual Guid ID { get; set; }
        public virtual string Name { get;protected set; }
        public virtual string Description { get; protected set; }
        /// <summary>
        /// 包含此Role的所有用户组
        /// </summary>
        public virtual List<Group> Groups { get; protected set; }

        public Role()
        {
        }

        public Role(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public virtual bool Equals(Role other)
        {
            return Name == other.Name;
        }
    }
}