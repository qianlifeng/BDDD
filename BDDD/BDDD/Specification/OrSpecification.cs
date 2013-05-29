using System;
using System.Linq.Expressions;

namespace BDDD.Specification
{
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
            : base(left, right)
        {
        }

        public override Expression<Func<T, bool>> GetExpression()
        {
            return Left.GetExpression().Or(Right.GetExpression());
        }
    }
}