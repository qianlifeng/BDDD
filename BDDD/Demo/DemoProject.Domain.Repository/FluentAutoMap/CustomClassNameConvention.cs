using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace DemoProject.Domain.Repository.FluentAutoMap
{
    /// <summary>
    /// 自定义表名
    /// </summary>
    public class CustomClassNameConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            string tableName = "t" + instance.EntityType.Name;
            instance.Table(tableName);
        }
    }
}
