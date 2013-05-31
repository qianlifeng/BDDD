using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoProject.DTO
{
    public class GroupDTO
    {
        public  Guid ID { get; set; }
        public  string Name { get;  set; }
        public  string Description { get;  set; }
        public  List<RoleDTO> Roles { get;  set; }
        /// <summary>
        /// 包含此组的所有用户
        /// </summary>
        public  List<UserDTO> Users { get;  set; } 
    }
}
