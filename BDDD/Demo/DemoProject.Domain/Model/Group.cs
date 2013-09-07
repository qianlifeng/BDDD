using System;
using System.Collections.Generic;
using BDDD;

namespace DemoProject.Domain.Model
{
    public class Group : IAggregateRoot, IEquatable<Group>
    {
        public virtual Guid ID { get; set; }
        public virtual string Name { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual IList<Role> Roles { get; protected set; }
        public virtual IList<User> Users { get; protected set; } 

        public Group()
        {
        }

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
