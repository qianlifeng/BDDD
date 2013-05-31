using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoProject.DTO
{
    public class RoleDTO
    {
        public  Guid ID { get; set; }
        public  string Name { get;  set; }
        public  string Description { get;  set; }
        /// <summary>
        /// 包含此Role的所有用户组
        /// </summary>
        public  List<GroupDTO> Groups { get;  set; }
    }
}
