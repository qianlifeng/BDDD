using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Specification
{
    /// <summary>
    /// 表明这是一个组合的Specification
    /// </summary>
    public interface ICompositeSpecification<T>
    {
        ISpecification<T> Left { get; }

        ISpecification<T> Right { get; }
    }
}
