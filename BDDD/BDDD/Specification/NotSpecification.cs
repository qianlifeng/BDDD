using System;
using System.Linq.Expressions;

namespace BDDD.Specification
{
    public class NotSpecification<T> : Specification<T>
    {
        private ISpecification<T> spec;

        public NotSpecification(ISpecification<T> spec)
        {
            this.spec = spec;
        }

        public override Expression<Func<T, bool>> GetExpression()
        {
            UnaryExpression body = Expression.Not(spec.GetExpression().Body);
            return Expression.Lambda<Func<T, bool>>(body, spec.GetExpression().Parameters);
        }
    }
}