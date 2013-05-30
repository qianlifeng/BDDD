using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DemoProject.Infrastructure
{
    public class ReflectUtil
    {
        /// <summary>
        /// 检查所有from对象中的属性，将其中不会空的属性更新到to对象中同名的属性上去
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns>返回更新后的对象</returns>
        public static TTo UpdateNotEmptyValues<TFrom, TTo>(TFrom from, TTo to)
        {
            Type fromType = from.GetType();
            Type toType = to.GetType();
            foreach (PropertyInfo pi in fromType.GetProperties())
            {
                object propertyValue = pi.GetValue(from, null);
                if (propertyValue != null)
                {
                    PropertyInfo toProperty = toType.GetProperty(pi.Name);
                    if (toProperty != null)
                    {
                        toProperty.SetValue(to,propertyValue,null);
                    }
                }
            }

            return to;
        }
    }
}
