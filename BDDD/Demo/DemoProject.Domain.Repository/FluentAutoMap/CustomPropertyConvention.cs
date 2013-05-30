using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace DemoProject.Domain.Repository.FluentAutoMap
{
    public class CustomPropertyConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            instance.Column(instance.Name);

            StringConvention(instance);
        }

        private static void StringConvention(IPropertyInstance instance)
        {
            if (instance.Type == typeof (String))
            {
                object[] attributes = instance.EntityType.GetProperty(instance.Name)
                                        .GetCustomAttributes(typeof (LengthAttribute), false);
                if (attributes.Length > 0)
                {
                    LengthAttribute length = attributes[0] as LengthAttribute;
                    if (length != null) instance.Length(length.Length);
                }
            }
        }
    }
}
