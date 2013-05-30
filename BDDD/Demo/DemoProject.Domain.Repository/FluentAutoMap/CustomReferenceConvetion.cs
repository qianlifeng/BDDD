using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace DemoProject.Domain.Repository.FluentAutoMap
{
    /// <summary>
    /// 一对多情况，多端的映射配置
    /// 比如，用户对应多个订单。则此配置订单下面的User属性在数据库中的映射情况
    /// </summary>
    public class CustomReferenceConvention : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            string colName = null;
            var referenceType = instance.Class.GetUnderlyingSystemType();
            var entityType = instance.EntityType;
            var propertyName = instance.Property.Name;
            //Self association
            if (referenceType == entityType)
                colName = "ParentId";
            else
                colName = propertyName + "Id";

            instance.Column(colName);
        }
    }

}
