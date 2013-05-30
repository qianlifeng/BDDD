using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace DemoProject.Domain.Repository.FluentAutoMap
{
    /// <summary>
    ///  多对多映射
    /// </summary>
    public class CustomManyToManyConvention : IHasManyToManyConvention
    {
        public void Apply(IManyToManyCollectionInstance instance)
        {
            var entityDatabaseName = instance.EntityType.Name;
            var childDatabaseName = instance.ChildType.Name;
            //之所以要对表格进行排序是为了在生成数据库的时候，不对生成两个连接表。
            //例如user 和 group 里面都持有对方的列表。此时会生成两个连接表。但是如果将他们的名字弄成一样，最终
            //只会生成一个连接表
            var name = "tMap"+ GetTableName(entityDatabaseName,childDatabaseName); //对两个表名进行排序，然后连接组成中间表名

            instance.Table(name);
            instance.Key.Column(entityDatabaseName + "Id");
            instance.Relationship.Column(childDatabaseName + "Id");
        }

        private string GetTableName(string a, string b)
        {
            var r = System.String.CompareOrdinal(a, b);
            if (r > 0)
            {
                return string.Format("{0}To{1}",b, a);
            }
            else
            {
                return string.Format("{0}To{1}",a, b);
            }
        }


    }
}
