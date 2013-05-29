using System;

namespace BDDD.Config
{
    public class ConfigException : BDDDException
    {
        public ConfigException()
        {
        }

        public ConfigException(string message) : base(message)
        {
        }

        public ConfigException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ConfigException(string format, params object[] args) : base(string.Format(format, args))
        {
        }
    }
}