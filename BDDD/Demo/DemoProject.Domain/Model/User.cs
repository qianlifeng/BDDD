using System;
using System.Collections.Generic;
using System.Linq;
using BDDD;

namespace DemoProject.Domain.Model
{
    public class User : IAggregateRoot
    {
        public virtual string UserName { get; protected set; }
        public virtual string NickName { get; protected set; }
        public virtual string Password { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual bool IsDisabled { get; protected set; }
        public virtual DateTime DateRegistered { get; protected set; }
        public virtual DateTime? DateLastLogin { get; protected set; }
        public virtual Guid ID { get; set; }
        public virtual IList<Group> UserGroups { get; protected set; }

        public User()
        {
        }

        public User(string userName, string password, List<Group> userGroups)
        {
            ID = Guid.NewGuid();
            UserName = userName;
            Password = password;
            UserGroups = userGroups;
            DateRegistered = DateTime.Now;
        }

        public User(string userName, string nickName, string email, string password, List<Group> userGroups)
            : this(userName, password, userGroups)
        {
            NickName = nickName;
            Email = email;
        }

        /// <summary>
        /// 判断用户是否包含特定的角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public virtual bool HasRole(Role role)
        {
            return UserGroups.Any(g => g.HasRole(role));
        }

        /// <summary>
        /// 返回此用户所有的Role
        /// </summary>
        /// <returns></returns>
        public virtual List<Role> GetAllRoles()
        {
            List<Role> roles = new List<Role>();
            UserGroups.ToList().ForEach(o => o.Roles.ToList().ForEach(r =>
                {
                    if (!roles.Contains(r))
                    {
                        roles.Add(r);
                    }
                }));
            return roles;
        }

    /// <summary>
        /// 是否属于某个用户组
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public virtual bool BelongInGroup(Group group)
        {
            return UserGroups.Contains(group);
        }

        /// <summary>
        ///     禁用当前账户。
        /// </summary>
        public virtual void Disable()
        {
            IsDisabled = true;
        }

        /// <summary>
        ///     启用当前账户。
        /// </summary>
        public virtual void Enable()
        {
            IsDisabled = false;
        }

        /// <summary>
        /// 讲该用户增加到指定分组
        /// </summary>
        /// <param name="group"></param>
        public virtual void AddToGroup(Group group)
        {
            UserGroups.Add(group);
        }

        /// <summary>
        /// 刷新用户上次登录时间为当前时间
        /// </summary>
        public virtual void UpdateLastLogin()
        {
            DateLastLogin = DateTime.Now;
        }

        public virtual List<Group> GetAllGroups()
        {
            return UserGroups.ToList();
        }
    }
}