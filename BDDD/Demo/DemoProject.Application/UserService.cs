using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using BDDD.ObjectContainer;
using DemoProject.DTO;
using DemoProject.Domain.Model;
using DemoProject.Domain.Repositories;
using DemoProject.IApplication;
using DemoProject.Infrastructure;

namespace DemoProject.Application
{
    public class UserService :ApplicationServiceBase,IUserService
    {
        private readonly IUserRepository userRepository = ServiceLocator.Instance.GetService<IUserRepository>();

        public bool ValidateUser(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException(userName);
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(password);

            return userRepository.CheckPassword(userName, password);
        }

        public bool DisableUser(UserDTO userDTO)
        {
            if (userDTO == null)
                throw new ArgumentNullException("用户不能为空");
            if (userDTO.ID.IsEmptyGuid())
                throw new ArgumentNullException("用户ID不能为空");

            User user = userRepository.GetByKey(userDTO.ID);
            user.Disable();
            userRepository.Update(user);
            RepositoryContext.Commit();
            return user.IsDisabled;
        }

        public bool EnableUser(UserDTO userDTO)
        {
            if (userDTO == null)
                throw new ArgumentNullException("用户不能为空");
            if (userDTO.ID.IsEmptyGuid())
                throw new ArgumentNullException("用户ID不能为空");

            User user = userRepository.GetByKey(userDTO.ID);
            user.Enable();
            userRepository.Update(user);
            RepositoryContext.Commit();
            return user.IsDisabled;
        }

        public UserDTO UpdateUsers(UserDTO userDTO)
        {
            if (userDTO == null)
                throw new ArgumentNullException("用户不能为空");
            if (userDTO.ID.IsEmptyGuid())
                throw new ArgumentNullException("用户ID不能为空");

            User user = userRepository.GetByKey(userDTO.ID);
            
            userRepository.Update(user);
            RepositoryContext.Commit();
            return user.IsDisabled;
        }

        public void DeleteUsers(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserByKey(Guid id)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserByName(string userName)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetUsers(Expression<Func<UserDTO, bool>> spec)
        {
            throw new NotImplementedException();
        }

        public List<RoleDTO> GetRoles()
        {
            throw new NotImplementedException();
        }

        public List<GroupDTO> GetGroups()
        {
            throw new NotImplementedException();
        }
    }
}
