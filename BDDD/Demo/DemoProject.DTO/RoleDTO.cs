using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoProject.DTO
{
    public class RoleDTO
    {
        public virtual Guid ID { get; set; }
        public virtual string Name { get;  set; }
        public virtual string Description { get;  set; }
        /// <summary>
        /// 包含此Role的所有用户组
        /// </summary>
        public virtual List<GroupDTO> Groups { get;  set; }
    }
}
