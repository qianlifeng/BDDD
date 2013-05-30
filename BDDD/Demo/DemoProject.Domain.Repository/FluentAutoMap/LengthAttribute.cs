using System;

namespace DemoProject.Domain.Repository.FluentAutoMap
{
    /// <summary>
    /// 指定在自动映射的时候的字符串长度
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class LengthAttribute : Attribute
    {
        public LengthAttribute(int length)
        {
            Length = length;
        }

        public int Length { get; set; }
    }
}
