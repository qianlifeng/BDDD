using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoProject.IApplication;
using BDDD.ObjectContainer;
using DemoProject.DTO;
using System.Collections.Generic;

namespace DemoProject.Test.Application
{
    [TestClass]
    public class MenuServiceTest : TestBase
    {
        private IMenuService menuService;
        MenuDTO menu1;
        MenuItemDTO menuItem1;
        MenuItemDTO menuItem2;
        MenuItemDTO menuItem3;
        MenuDTO menu2;
        MenuDTO menu3;


        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            InitAppRuntime();
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            menuService = ServiceLocator.Instance.GetService<IMenuService>();
            menu1 = new MenuDTO
            {
                Name = "用户管理",
                Category = "AdminMenu",
                OrderIndex = 10
            };
            menuItem1 = new MenuItemDTO
            {
                Name = "管理1",
                URL = "#",
                OrderIndex = 10
            };
            menuItem2 = new MenuItemDTO
            {
                Name = "管理2",
                URL = "#",
                OrderIndex = 20
            };
            menuItem2 = new MenuItemDTO
            {
                Name = "管理3",
                URL = "#",
                OrderIndex = 30
            };
            menu2 = new MenuDTO
            {
                Name = "公告管理",
                Category = "AdminMenu",
                OrderIndex = 20
            };
            menu3 = new MenuDTO
            {
                Name = "菜单管理",
                Category = "AdminMenu",
                OrderIndex = 30
            };
        }

        [TestMethod]
        public void AddMenuTest()
        {
            MenuDTO menu = menuService.AddMenu(menu1);
            Assert.IsTrue(menu.ID != Guid.Empty);
        }

        [TestMethod]
        public void AddMenuItemTest()
        {
            MenuDTO menu = menuService.AddMenu(menu2);
            Assert.IsTrue(menu.ID != Guid.Empty);

            MenuItemDTO item = menuService.AddMenuItem(menu.ID, menuItem1);

            Assert.IsTrue(item.ID != Guid.Empty);
        }

        [TestMethod]
        public void GetMenuTest()
        {
            List<MenuDTO> oldMenus = menuService.GetMenus(menu1.Category);

            menuService.AddMenu(menu1);
            menuService.AddMenu(menu2);
            menuService.AddMenu(menu3);

            List<MenuDTO> menus = menuService.GetMenus(menu1.Category);

            Assert.IsTrue(menus.Count == oldMenus.Count + 3);
        }
    }
}
