using System;
using System.Linq.Expressions;

namespace BDDD.Specification
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public bool IsSatisfiedBy(T obj)
        {
            return GetExpression().Compile()(obj);
        }

        public ISpecification<T> And(ISpecification<T> other)
        {
            return new AndSpecification<T>(this, other);
        }

        public ISpecification<T> Or(ISpecification<T> other)
        {
            return new OrSpecification<T>(this, other);
        }

        public ISpecification<T> Not()
        {
            return new NotSpecification<T>(this);
        }

        /// <summary>
        ///     使用LINQ表达式树表达规约（Specification）
        /// </summary>
        /// <returns>The LINQ expression.</returns>
        public abstract Expression<Func<T, bool>> GetExpression();

        /// <summary>
        ///     由LINQ表达式获得一个临时规约，避免了所有的条件都要创建一个规约的繁琐
        /// </summary>
        /// <param name="expression">LINQ表达式</param>
        /// <returns>返回的规约</returns>
        public static ISpecification<T> Eval(Expression<Func<T, bool>> expression)
        {
            return new ExpressionSpecification<T>(expression);
        }
    }
}