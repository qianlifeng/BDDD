using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoProject.DTO
{
    public class GroupDTO :BaseDTO
    {
        public virtual string Name { get;  set; }
        public virtual string Description { get;  set; }
        public virtual List<RoleDTO> Roles { get;  set; }
        /// <summary>
        /// 包含此组的所有用户
        /// </summary>
        public virtual List<UserDTO> Users { get;  set; } 
    }
}
