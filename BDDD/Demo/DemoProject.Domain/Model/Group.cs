using System;
using System.Collections.Generic;
using BDDD;

namespace DemoProject.Domain.Model
{
    public class Group : IAggregateRoot, IEquatable<Group>
    {
        public virtual Guid ID { get; set; }
        public virtual string Name { get; private set; }
        public virtual string Description { get;private set; }
        public virtual List<Role> Roles { get; private set; }

        public Group(string name, string description, List<Role> roles)
        {
            Roles = roles;
            Name = name;
            Description = description;
        }

        public virtual bool HasRole(Role role)
        {
            return Roles.Contains(role);
        }

        public virtual void AddRole(Role role)
        {
            Roles.Add(role);
        }


        public virtual void RemoveRole(Role role)
        {
            Roles.Remove(role);
        }

        public virtual bool Equals(Group other)
        {
            return Name == other.Name;
        }


    }
}
