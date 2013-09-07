using BDDD.ObjectContainer;
using DemoProject.Application;
using DemoProject.Domain.Repositories;
using DemoProject.IApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DemoProject.DTO;
using System.Collections.Generic;
using BDDD.Specification;
using DemoProject.DTO.Admin;

namespace DemoProject.Test.Application
{
    [TestClass()]
    public class UserServiceTest : TestBase
    {
        private TestContext testContextInstance;
        private IUserService userService;
        private UserDTO userDTO1;
        private UserDTO userDTO2;
        private UserDTO userDTO3;

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            InitAppRuntime();
        }

        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            userService = ServiceLocator.Instance.GetService<IUserService>();
            userDTO1 = new UserDTO()
                {
                    UserName = "user1",
                    Password = "pwd1",
                    DateLastLogin = DateTime.Now,
                    DateRegistered = DateTime.Now,
                    Email = "mail1",
                    IsDisabled = false,
                    NickName = "qlf1"
                };

            userDTO2 = new UserDTO()
            {
                UserName = "user2",
                Password = "pwd2",
                DateLastLogin = DateTime.Now,
                DateRegistered = DateTime.Now,
                Email = "mail2",
                IsDisabled = false,
                NickName = "qlf2"
            };
            userDTO3 = new UserDTO()
            {
                UserName = "user3",
                Password = "pwd3",
                DateLastLogin = DateTime.Now,
                DateRegistered = DateTime.Now,
                Email = "mail3",
                IsDisabled = false,
                NickName = "qlf3"
            };

            Console.WriteLine("reset db....");
            ResetDB();
        }

        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for UserService Constructor
        ///</summary>
        [TestMethod()]
        public void UserServiceConstructorTest()
        {
            Assert.IsTrue(userService != null);
        }

        [TestMethod()]
        public void AddUserTest()
        {
            Assert.IsTrue(userDTO1.ID == Guid.Empty);
            userDTO1 = userService.AddUser(userDTO1);
            Assert.IsTrue(userDTO1.ID != Guid.Empty);
        }

        [TestMethod()]
        public void DeleteUsersTest()
        {
            Assert.IsTrue(userDTO1.ID == Guid.Empty);
            userDTO1 = userService.AddUser(userDTO1);
            Assert.IsTrue(userDTO1.ID != Guid.Empty);

            Guid id = userDTO1.ID;
            userService.DeleteUser(userDTO1);
            UserDTO userByKey = userService.GetUserByKey(id);
            Assert.IsTrue(userByKey == null);
        }

        /// <summary>
        ///A test for DisableUser
        ///</summary>
        [TestMethod()]
        public void DisableUserTest()
        {
            Assert.IsTrue(userDTO1.ID == Guid.Empty);
            userDTO1 = userService.AddUser(userDTO1);
            Assert.IsTrue(userDTO1.ID != Guid.Empty);

            userDTO1.IsDisabled = false;
            userService.DisableUser(userDTO1);
            UserDTO userByKey = userService.GetUserByKey(userDTO1.ID);
            Assert.IsTrue(userByKey.IsDisabled == true);
        }

        /// <summary>
        ///A test for EnableUser
        ///</summary>
        [TestMethod()]
        public void EnableUserTest()
        {
            Assert.IsTrue(userDTO1.ID == Guid.Empty);
            userDTO1 = userService.AddUser(userDTO1);
            Assert.IsTrue(userDTO1.ID != Guid.Empty);

            userDTO1.IsDisabled = true;
            userService.EnableUser(userDTO1);
            UserDTO userByKey = userService.GetUserByKey(userDTO1.ID);
            Assert.IsTrue(userByKey.IsDisabled == false);
        }

        /// <summary>
        ///A test for GetUserGroups
        ///</summary>
        [TestMethod()]
        public void GetGroupsTest()
        {

        }

        /// <summary>
        ///A test for GetUserRoles
        ///</summary>
        [TestMethod()]
        public void GetRolesTest()
        {

        }

        /// <summary>
        ///A test for GetUserByEmail
        ///</summary>
        [TestMethod()]
        public void GetUserByEmailTest()
        {
            userDTO1.Email = "meail" + DateTime.Now;
            userDTO1 = userService.AddUser(userDTO1);
            Assert.IsTrue(userDTO1.ID != Guid.Empty);

            UserDTO userByEmail = userService.GetUserByEmail(userDTO1.Email);
            Assert.IsTrue(userDTO1.ID == userByEmail.ID);
        }

        /// <summary>
        ///A test for GetUserByKey
        ///</summary>
        [TestMethod()]
        public void GetUserByKeyTest()
        {
            userDTO1 = userService.AddUser(userDTO1);
            Assert.IsTrue(userDTO1.ID != Guid.Empty);

            UserDTO userByEmail = userService.GetUserByKey(userDTO1.ID);
            Assert.IsTrue(userDTO1.ID == userByEmail.ID);
        }

        /// <summary>
        ///A test for GetUserByName
        ///</summary>
        [TestMethod()]
        public void GetUserByNameTest()
        {
            userDTO1.UserName = "name" + DateTime.Now;
            userDTO1 = userService.AddUser(userDTO1);
            Assert.IsTrue(userDTO1.ID != Guid.Empty);

            UserDTO byName = userService.GetUserByName(userDTO1.UserName);
            Assert.IsTrue(userDTO1.ID == byName.ID);
        }

        /// <summary>
        ///A test for GetUsers
        ///</summary>
        [TestMethod()]
        public void GetUsersTest()
        {
            userDTO1.UserName = "thisistest1";
            userService.AddUser(userDTO1);
            userDTO2.UserName = "thisistest2";
            userService.AddUser(userDTO2);
            userDTO3.UserName = "qlf3";
            userService.AddUser(userDTO3);

            UserDTO u = userService.GetUserByName("thisistest1");
            Assert.IsTrue(u.ID != Guid.Empty);

            List<UserDTO> userDtos = userService.GetUsers(o => o.UserName.Contains("1"));
            Assert.IsTrue(userDtos.Count == 1);
        }

        /// <summary>
        ///A test for UpdateUser
        ///</summary>
        [TestMethod()]
        public void UpdateUserTest()
        {
            userDTO1.UserName = "111";
            userDTO1.Password = "222";
            userDTO1 = userService.AddUser(userDTO1);
            Assert.IsTrue(userDTO1.ID != Guid.Empty);

            userDTO1.UserName = "test";
            userDTO1 = userService.UpdateUser(userDTO1);
            Assert.IsTrue(userDTO1.UserName == "test");
        }

        /// <summary>
        ///A test for ValidateUser
        ///</summary>
        [TestMethod()]
        public void ValidateUserTest()
        {
            userDTO1.UserName = "111";
            userDTO1.Password = "222";
            userDTO1 = userService.AddUser(userDTO1);
            Assert.IsTrue(userDTO1.ID != Guid.Empty);

            AdminLoginDTO dto = new AdminLoginDTO
            {
                UserName = "111",
                Password = "222"
            };

            bool canLogin = userService.ValidateUser(dto);
            Assert.IsTrue(canLogin);
        }
    }
}
