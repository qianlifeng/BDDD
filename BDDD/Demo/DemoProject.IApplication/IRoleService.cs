using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DemoProject.DTO;

namespace DemoProject.IApplication
{
    public interface IRoleService
    {
        /// <summary>
        /// 获得系统中所有的Role
        /// </summary>
        /// <returns></returns>
        List<RoleDTO> GetAllRoles();

        /// <summary>
        /// 添加新的角色
        /// </summary>
        /// <param name="RoleDTO"></param>
        /// <returns></returns>
        RoleDTO AddRole(RoleDTO RoleDTO);

        /// <summary>
        /// 获得指定角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RoleDTO GetRoleByKey(Guid id);

        /// <summary>
        /// 删除某个角色，此操作会删除所有用户组下面此角色
        /// </summary>
        /// <param name="RoleDTO"></param>
        void DeleteRole(RoleDTO RoleDTO);

        /// <summary>
        /// 更新某个用户角色
        /// </summary>
        /// <param name="RoleDTO"></param>
        /// <returns></returns>
        RoleDTO UpdateRole(RoleDTO RoleDTO);
    }
}
