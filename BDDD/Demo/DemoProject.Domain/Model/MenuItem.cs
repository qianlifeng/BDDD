using BDDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoProject.Domain.Model
{
    public class MenuItem : IEntity
    {
        public virtual string Name { get; set; }
        public virtual int IndexOrder { get; set; }
        public virtual string URL { get; set; }
        /// <summary>
        /// 此子菜单可见的role
        /// </summary>
        public virtual IList<Role> VisibleRoles { get; set; }
    }
}
