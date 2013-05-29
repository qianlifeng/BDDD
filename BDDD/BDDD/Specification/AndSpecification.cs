using System;
using System.Linq.Expressions;

namespace BDDD.Specification
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, right)
        {
        }

        public override Expression<Func<T, bool>> GetExpression()
        {
            return Left.GetExpression().And(Right.GetExpression());
        }
    }
}