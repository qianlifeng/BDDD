using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DemoProject.DTO;

namespace DemoProject.IApplication
{
    public interface IGroupService
    {
        /// <summary>
        /// 获得系统中所有的Group
        /// </summary>
        /// <returns></returns>
        List<GroupDTO> GetAllGroups();

        /// <summary>
        /// 添加新的用户组
        /// </summary>
        /// <param name="groupDTO"></param>
        /// <returns></returns>
        GroupDTO AddGroup(GroupDTO groupDTO);

        /// <summary>
        /// 获得指定用户组
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GroupDTO GetGroupByKey(Guid id);

        /// <summary>
        /// 删除某个用户组，此操作会删除所有用户下面此分组
        /// </summary>
        /// <param name="groupDTO"></param>
        void DeleteGroup(GroupDTO groupDTO);

        /// <summary>
        /// 更新某个用户分组
        /// </summary>
        /// <param name="groupDTO"></param>
        /// <returns></returns>
        GroupDTO UpdateGroup(GroupDTO groupDTO);
    }
}
