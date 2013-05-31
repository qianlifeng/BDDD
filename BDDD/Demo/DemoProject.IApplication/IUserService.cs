using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BDDD.Specification;
using DemoProject.DTO;

namespace DemoProject.IApplication
{
    public interface IUserService
    {
        /// <summary>
        /// 校验指定的用户用户名与密码是否一致。
        /// </summary>
        bool ValidateUser(string userName, string password);

        /// <summary>
        /// 禁用指定用户。
        /// </summary>
        bool DisableUser(UserDTO userDTO);

        /// <summary>
        /// 启用指定用户。
        /// </summary>
        bool EnableUser(UserDTO user);

        /// <summary>
        /// 根据指定的用户信息，更新用户对象。
        /// </summary>
        UserDTO UpdateUser(UserDTO user);

        /// <summary>
        ///  增加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        UserDTO AddUser(UserDTO user);

        /// <summary>
        /// 删除用户。
        /// </summary>
        void DeleteUser(UserDTO user);

        /// <summary>
        /// 根据用户的全局唯一标识获取用户信息。
        /// </summary>
        UserDTO GetUserByKey(Guid id);
        // ReSharper restore InconsistentNaming

        /// <summary>
        /// 根据用户的电子邮件地址获取用户信息。
        /// </summary>
        UserDTO GetUserByEmail(string email);

        /// <summary>
        /// 根据用户的用户名获取用户信息。
        /// </summary>
        UserDTO GetUserByName(string userName);

        /// <summary>
        /// 获取所有用户的信息。
        /// </summary>
        List<UserDTO> GetUsers(ISpecification<UserDTO> spec);

        /// <summary>
        /// 获取所有角色。
        /// </summary>
        List<RoleDTO> GetUserRoles();

        /// <summary>
        /// 获取所有用户分组。
        /// </summary>
        List<GroupDTO> GetUserGroups();
    }
}
