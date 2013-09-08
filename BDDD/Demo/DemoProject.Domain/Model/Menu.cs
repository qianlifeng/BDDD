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
        public virtual int OrderIndex { get; protected set; }
        /// <summary>
        /// 此菜单可见的Role
        /// </summary>
        public virtual IList<Role> VisibleRoles { get; protected set; }

        public Menu() { }

        public Menu(string name, string category,int order)
        {
            Name = name;
            Category = category;
            OrderIndex = order;
        }

        /// <summary>
        /// 添加菜单项
        /// </summary>
        public virtual void AddMenuItem(MenuItem item)
        {
            if (Items.ToList().Any(o => o.Name == item.Name && o.URL == item.URL)) {
                throw new ArgumentException("相同名字和URL的子菜单项已经存在");
            }

            Items.Add(item);
        }

        public virtual void RemoveMenuItem(string name)
        {
            MenuItem item = Items.Where(o => o.Name == name).FirstOrDefault();
            if (!string.IsNullOrEmpty(item.Name))
            {
                Items.Remove(item);
            }
        }

        public virtual void ChangeMenuName(string newName)
        {
            Name = newName;
        }

        public virtual void ChangeCategory(string newCategory)
        {
            Category = newCategory;
        }

        public virtual Guid ID
        {
            get;
            set;
        }
    }
}
