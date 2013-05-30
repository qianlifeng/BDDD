using BDDD.ObjectContainer;
using DemoProject.Application;
using DemoProject.Domain.Repositories;
using DemoProject.IApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DemoProject.DTO;
using System.Collections.Generic;
using BDDD.Specification;

namespace DemoProject.Test.Application
{
    [TestClass()]
    public class UserServiceTest : TestBase
    {
        private TestContext testContextInstance;
        private IUserService userService = ServiceLocator.Instance.GetService<IUserService>();
        private UserDTO userDTO1;
        private UserDTO userDTO2;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

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
            userDTO1 =  userService.AddUser(userDTO1);
            Assert.IsTrue(userDTO1.ID != Guid.Empty);
        }

        [TestMethod()]
        public void DeleteUsersTest()
        {
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DisableUser
        ///</summary>
        [TestMethod()]
        public void DisableUserTest()
        {
            UserService userService = new UserService(); // TODO: Initialize to an appropriate value
            UserDTO userDTO = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = userService.DisableUser(userDTO);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EnableUser
        ///</summary>
        [TestMethod()]
        public void EnableUserTest()
        {
            UserService userService = new UserService(); // TODO: Initialize to an appropriate value
            UserDTO userDTO = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = userService.EnableUser(userDTO);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetGroups
        ///</summary>
        [TestMethod()]
        public void GetGroupsTest()
        {
            UserService userService = new UserService(); // TODO: Initialize to an appropriate value
            List<GroupDTO> expected = null; // TODO: Initialize to an appropriate value
            List<GroupDTO> actual;
            actual = userService.GetGroups();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetRoles
        ///</summary>
        [TestMethod()]
        public void GetRolesTest()
        {
            UserService userService = new UserService(); // TODO: Initialize to an appropriate value
            List<RoleDTO> expected = null; // TODO: Initialize to an appropriate value
            List<RoleDTO> actual;
            actual = userService.GetRoles();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUserByEmail
        ///</summary>
        [TestMethod()]
        public void GetUserByEmailTest()
        {
            UserService userService = new UserService(); // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            UserDTO expected = null; // TODO: Initialize to an appropriate value
            UserDTO actual;
            actual = userService.GetUserByEmail(email);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUserByKey
        ///</summary>
        [TestMethod()]
        public void GetUserByKeyTest()
        {
            UserService userService = new UserService(); // TODO: Initialize to an appropriate value
            Guid id = new Guid(); // TODO: Initialize to an appropriate value
            UserDTO expected = null; // TODO: Initialize to an appropriate value
            UserDTO actual;
            actual = userService.GetUserByKey(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUserByName
        ///</summary>
        [TestMethod()]
        public void GetUserByNameTest()
        {
            UserService userService = new UserService(); // TODO: Initialize to an appropriate value
            string userName = string.Empty; // TODO: Initialize to an appropriate value
            UserDTO expected = null; // TODO: Initialize to an appropriate value
            UserDTO actual;
            actual = userService.GetUserByName(userName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetUsers
        ///</summary>
        [TestMethod()]
        public void GetUsersTest()
        {
            UserService userService = new UserService(); // TODO: Initialize to an appropriate value
            ISpecification<UserDTO> spec = null; // TODO: Initialize to an appropriate value
            List<UserDTO> expected = null; // TODO: Initialize to an appropriate value
            List<UserDTO> actual;
            actual = userService.GetUsers(spec);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateUser
        ///</summary>
        [TestMethod()]
        public void UpdateUserTest()
        {
            UserService userService = new UserService(); // TODO: Initialize to an appropriate value
            UserDTO userDTO = null; // TODO: Initialize to an appropriate value
            UserDTO expected = null; // TODO: Initialize to an appropriate value
            UserDTO actual;
            actual = userService.UpdateUser(userDTO);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateUser
        ///</summary>
        [TestMethod()]
        public void UpdateUsersTest()
        {
            UserService userService = new UserService(); // TODO: Initialize to an appropriate value
            UserDTO user = null; // TODO: Initialize to an appropriate value
            UserDTO expected = null; // TODO: Initialize to an appropriate value
            UserDTO actual;
            actual = userService.UpdateUser(user);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ValidateUser
        ///</summary>
        [TestMethod()]
        public void ValidateUserTest()
        {
            UserService userService = new UserService(); // TODO: Initialize to an appropriate value
            string userName = string.Empty; // TODO: Initialize to an appropriate value
            string password = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = userService.ValidateUser(userName, password);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
