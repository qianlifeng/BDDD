namespace BDDD.Events
{
    public interface IHandler<T>
    {
        bool Handle(T message);
    }
}