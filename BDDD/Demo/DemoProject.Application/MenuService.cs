using AutoMapper;
using DemoProject.Domain.Model;
using DemoProject.Domain.Repositories;
using DemoProject.DTO;
using DemoProject.IApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoProject.Application
{
    public class MenuService : ApplicationServiceBase, IMenuService
    {
        private IMenuRepository menuRepository;

        public MenuService()
        {
            menuRepository = GetResolvedRepository<IMenuRepository>();
        }

        public List<MenuDTO> GetMenus(string category)
        {
            if (string.IsNullOrEmpty(category))
                throw new ArgumentNullException("菜单分类不能为空");

            return Mapper.Map<List<Menu>, List<MenuDTO>>(menuRepository.GetAll(o => o.Category == category).ToList());
        }

        public MenuDTO AddMenu(MenuDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Name))
                throw new ArgumentNullException("菜单名字不能为空");
            if (string.IsNullOrEmpty(dto.Category))
                throw new ArgumentNullException("菜单分类不能为空");
            if (dto.OrderIndex <= 0)
                throw new ArgumentNullException("菜单排序必须大于0");

            Menu menu = Mapper.Map<MenuDTO, Menu>(dto);
            menuRepository.Add(menu);
            RepositoryContext.Commit();

            return Mapper.Map<Menu, MenuDTO>(menu);
        }

        public MenuItemDTO AddMenuItem(Guid id, MenuItemDTO dto)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("父菜单不能为空");
            if (string.IsNullOrEmpty(dto.Name))
                throw new ArgumentNullException("菜单名字不能为空");
            if (string.IsNullOrEmpty(dto.URL))
                throw new ArgumentNullException("菜单地址不能为空");
            if (dto.OrderIndex <= 0)
                throw new ArgumentNullException("菜单排序必须大于0");

            Menu menu = menuRepository.GetByKey(id);
            if (menu == null || menu.ID == Guid.Empty)
            {
                throw new ArgumentNullException("父菜单不存在");
            }

            MenuItem menuItem = Mapper.Map<MenuItemDTO, MenuItem>(dto);
            menu.AddMenuItem(menuItem);
            menuRepository.Update(menu);
            RepositoryContext.Commit();

            return Mapper.Map<MenuItem, MenuItemDTO>(menuItem);
        }

        public bool CanAccessByUser(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
