namespace BDDD.Specification
{
    /// <summary>
    ///     表明这是一个组合的Specification
    /// </summary>
    public interface ICompositeSpecification<T>
    {
        ISpecification<T> Left { get; }

        ISpecification<T> Right { get; }
    }
}