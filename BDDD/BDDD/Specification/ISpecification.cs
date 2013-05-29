using System;
using System.Linq.Expressions;

namespace BDDD.Specification
{
    /// <summary>
    ///     Specification模式，这里实现的规约模式是基于LINQ表达式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        ///     给定的对象是否满足此规约
        /// </summary>
        /// <param name="obj">要检测的对象</param>
        /// <returns>如果满足则返回true，否则false</returns>
        bool IsSatisfiedBy(T obj);

        /// <summary>
        ///     将当前的规约与给定的规约合并成一个新的规约。
        ///     合并后的规约是两个子规约的And关系
        /// </summary>
        /// <param name="other">要合并的规约</param>
        /// <returns>合并后的新规约</returns>
        ISpecification<T> And(ISpecification<T> other);

        /// <summary>
        ///     将当前的规约与给定的规约合并成一个新的规约。
        ///     合并后的规约是两个子规约的Or关系
        /// </summary>
        /// <param name="other">要合并的规约</param>
        /// <returns>合并后的新规约</returns>
        ISpecification<T> Or(ISpecification<T> other);

        /// <summary>
        ///     取当前规约的反
        /// </summary>
        /// <returns></returns>
        ISpecification<T> Not();

        /// <summary>
        ///     得到当前规约的LINQ表达式，可用于其他ORM进行数据库检索
        /// </summary>
        /// <returns></returns>
        Expression<Func<T, bool>> GetExpression();
    }
}