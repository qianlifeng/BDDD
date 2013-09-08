using DemoProject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoProject.IApplication
{
    public interface IMenuService
    {
        List<MenuDTO> GetMenus(string category);

        MenuDTO AddMenu(MenuDTO dto);

        MenuItemDTO AddMenuItem(Guid id, MenuItemDTO dto);

        bool CanAccessByUser(Guid userId);
    }
}
