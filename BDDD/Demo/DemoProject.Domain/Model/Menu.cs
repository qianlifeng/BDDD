using BDDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoProject.Domain.Model
{
    public class Menu : IAggregateRoot
    {
        public virtual string Name { get; protected set; }
        /// <summary>
        /// 菜单分类，比如前台菜单和后台菜单可以分在不同的类别里面
        /// </summary>
        public virtual string Category { get; protected set; }
        public virtual IList<MenuItem> Items { get; protected set; }
        /// <summary>
        /// 此菜单可见的Role
        /// </summary>
        public virtual IList<Role> VisibleRoles { get; protected set; }

        public Menu(string name, string category)
        {
            Name = name;
            Category = category;
        }

        /// <summary>
        /// 添加菜单项
        /// </summary>
        /// <param name="name"></param>
        /// <param name="url"></param>
        /// <param name="order">子菜单顺序，越小越靠前</param>
        public void AddMenuItem(string name, string url, int order)
        {
            Items.Add(new MenuItem
            {
                Name = name,
                URL = url,
                IndexOrder = order
            });
        }

        public void RemoveMenuItem(string name)
        { 
            MenuItem item = Items.Where(o=>o.Name == name).FirstOrDefault();
            if(!string.IsNullOrEmpty(item.Name))
            {
                Items.Remove(item);
            }
        }

        public void ChangeMenuName(string newName)
        {
            Name = newName;
        }

        public void ChangeCategory(string newCategory)
        {
            Category = newCategory;
        }
    }
}
