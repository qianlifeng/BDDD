using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoProject.DTO
{
    public class MenuDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int OrderIndex { get; set; }
        public List<MenuItemDTO> Items { get; set; }
    }

    public class MenuItemDTO : BaseDTO
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public int OrderIndex { get; set; }
    }
}
