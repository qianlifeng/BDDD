using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace DemoProject.Domain.Repository.FluentAutoMap
{
    /// <summary>
    /// 一对多情况，一端的映射配置
    /// 比如，用户对应多个订单。则此配置User类型面的订单集合在数据库中的名字
    /// </summary>
    public class CustomCollectionConvention : ICollectionConvention
    {
        public void Apply(ICollectionInstance instance)
        {
            string colName;
            var entityType = instance.EntityType;
            var childType = instance.ChildType;
            if (entityType == childType)//这里是专门对自身关联一对多的情况进行特殊处理，统一使用PARENT_ID作为外键列
                colName = "ParentId";
            else
            {
                colName = entityType.Name + "Id";
            }
            instance.Key.Column(colName);
            //instance.Cascade.AllDeleteOrphan();
        }
    }
}
