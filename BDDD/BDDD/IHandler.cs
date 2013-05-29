namespace BDDD
{
    public interface IHandler<T>
    {
        bool Handle(T message);
    }
}