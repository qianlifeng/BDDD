using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using BDDD.Specification;
using DemoProject.DTO;
using DemoProject.Domain.Model;
using DemoProject.Domain.Repositories;
using DemoProject.IApplication;
using DemoProject.Infrastructure;

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
            User user = userRepository.GetByKey(id);
            if (user != null)
            {
                return Mapper.Map<User, UserDTO>(user);
            }
            return null;
        }

        public UserDTO GetUserByEmail(string email)
        {
            User user = userRepository.GetSignal(o => o.Email == email);
            if (user != null)
            {
                return Mapper.Map<User, UserDTO>(user);
            }
            return null;
        }

        public UserDTO GetUserByName(string userName)
        {
            User user = userRepository.GetSignal(o => o.UserName == userName);
            if (user != null)
            {
                return Mapper.Map<User, UserDTO>(user);
            }
            return null;
        }

        public List<UserDTO> GetUsers(Expression<Func<UserDTO, bool>> spec)
        {
            Expression<Func<User, bool>> newExpression = ExpressionConvertor<UserDTO, User>.Convert(spec);
            IEnumerable<User> users = userRepository.GetAll(newExpression);
            return Mapper.Map<List<User>, List<UserDTO>>(users.ToList());
        }

        public List<RoleDTO> GetUserRoles(UserDTO userDTO)
        {
            ValidateUser(userDTO);

            User user = userRepository.GetByKey(userDTO.ID);
            if (user == null) throw new ApplicationException("用户不存在");

            return Mapper.Map<List<Role>, List<RoleDTO>>(user.GetAllRoles());
        }

        public List<GroupDTO> GetUserGroups(UserDTO userDTO)
        {
            ValidateUser(userDTO);

            User user = userRepository.GetByKey(userDTO.ID);
            if (user == null) throw new ApplicationException("用户不存在");

            return Mapper.Map<List<Group>, List<GroupDTO>>(user.GetAllGroups());
        }
    }
}
