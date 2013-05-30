using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using BDDD.Application;
using BDDD.ObjectContainer;
using BDDD.Specification;
using DemoProject.DTO;
using DemoProject.Domain.Model;
using DemoProject.Domain.Repositories;
using DemoProject.IApplication;
using DemoProject.Infrastructure;
using Microsoft.Practices.Unity;

namespace DemoProject.Application
{
    public class UserService : ApplicationServiceBase, IUserService
    {
        private IUserRepository userRepository;

        public UserService()
        {
            userRepository = GetResolvedRepository<IUserRepository>();
        }

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
            ValidateUser(userDTO);

            User user = userRepository.GetByKey(userDTO.ID);
            user.Disable();
            userRepository.Update(user);
            RepositoryContext.Commit();
            return user.IsDisabled;
        }

        public bool EnableUser(UserDTO userDTO)
        {
            ValidateUser(userDTO);

            User user = userRepository.GetByKey(userDTO.ID);
            user.Enable();
            userRepository.Update(user);
            RepositoryContext.Commit();
            return user.IsDisabled;
        }

        public UserDTO AddUser(UserDTO userDTO)
        {
            if (userDTO == null)
                throw new ArgumentNullException("用户不能为空");

            User user = Mapper.Map<UserDTO, User>(userDTO);
            userRepository.Add(user);
            RepositoryContext.Commit();
            return Mapper.Map<User, UserDTO>(user);
        }

        public UserDTO UpdateUser(UserDTO userDTO)
        {
            ValidateUser(userDTO);

            User user = userRepository.GetByKey(userDTO.ID);
            user = ReflectUtil.UpdateNotEmptyValues(userDTO, user);
            userRepository.Update(user);
            RepositoryContext.Commit();
            return Mapper.Map<User, UserDTO>(user);
        }

        private void ValidateUser(UserDTO userDTO)
        {
            if (userDTO == null)
                throw new ArgumentNullException("用户不能为空");
            if (userDTO.ID.IsEmptyGuid())
                throw new ArgumentNullException("用户ID不能为空");
        }

        public void DeleteUser(UserDTO userDTO)
        {
            ValidateUser(userDTO);

            User user = userRepository.GetByKey(userDTO.ID);
            userRepository.Remove(user);
            RepositoryContext.Commit();
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

        public List<UserDTO> GetUsers(ISpecification<UserDTO> spec)
        {
            ISpecification<User> userSpec = Mapper.Map<ISpecification<UserDTO>, ISpecification<User>>(spec);
            return Mapper.Map<IEnumerable<User>, List<UserDTO>>(userRepository.GetAll(userSpec));
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
