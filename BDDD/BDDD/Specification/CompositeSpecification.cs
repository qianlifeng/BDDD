using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Specification
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CompositeSpecification<T> : Specification<T>, ICompositeSpecification<T>
    {
        private readonly ISpecification<T> left;
        private readonly ISpecification<T> right;

        public CompositeSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public ISpecification<T> Left
        {
            get { return left; }
        }

        public ISpecification<T> Right
        {
            get { return right; }
        }
    }
}
