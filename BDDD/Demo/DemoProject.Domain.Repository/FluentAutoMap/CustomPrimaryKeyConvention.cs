using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace DemoProject.Domain.Repository.FluentAutoMap
{
    public class CustomPrimaryKeyConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            //规定所有表的主键都是ID
            instance.Column("ID");
            //主键自增
            instance.GeneratedBy.Guid();
        }
    }
}
