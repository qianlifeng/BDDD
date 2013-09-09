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
    public class DBTest : TestBase
    {
        [TestMethod]
        public void InitDBTest()
        {
            InitAppRuntime();

            ResetDB();

            IUserService userService = ServiceLocator.Instance.GetService<IUserService>();
            UserDTO user = new UserDTO()
                {
                    UserName = "1",
                    Password = "1",
                    DateLastLogin = DateTime.Now,
                    DateRegistered = DateTime.Now,
                    Email = "mail1",
                    IsDisabled = false,
                    NickName = "qlf1"
                };
            user = userService.AddUser(user);
            Assert.IsTrue(user.ID != Guid.Empty);

            IMenuService menuService = ServiceLocator.Instance.GetService<IMenuService>();
            MenuDTO userMenu = new MenuDTO
            {
                Name = "用户管理",
                Category = "AdminMenu",
                OrderIndex = 10
            };
            MenuDTO menu = new MenuDTO
            {
                Name = "菜单管理",
                Category = "AdminMenu",
                OrderIndex = 20
            };
            userMenu = menuService.AddMenu(userMenu);
            menu = menuService.AddMenu(menu);
            Assert.IsTrue(userMenu.ID != Guid.Empty);


            MenuItemDTO menuItem1 = new MenuItemDTO
            {
                Name = "用户管理",
                URL = "#",
                OrderIndex = 10
            };
            menuItem1 = menuService.AddMenuItem(userMenu.ID, menuItem1);

            MenuItemDTO menuItem2 = new MenuItemDTO
            {
                Name = "新增菜单",
                URL = "#",
                OrderIndex = 20
            };
            MenuItemDTO menuItem3 = new MenuItemDTO
            {
                Name = "菜单列表",
                URL = "/angularTemplates/admin/menulist.html",
                OrderIndex = 30
            };
            menuItem2 = menuService.AddMenuItem(menu.ID, menuItem2);
            menuItem3 = menuService.AddMenuItem(menu.ID, menuItem3);

            Assert.IsTrue(menuItem1.ID != Guid.Empty);
        }
    }
}
