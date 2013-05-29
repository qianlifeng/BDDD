namespace BDDD.Config
{
    /// <summary>
    ///     通过实现此接口以获得不同操作配置文件方式
    /// </summary>
    public interface IConfigSource
    {
        BDDDConfigSection Config { get; }
    }
}