using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Config
{
    public class ConfigException : BDDDException
    {
        public ConfigException() : base() { }
        public ConfigException(string message) : base(message) { }
        public ConfigException(string message, Exception innerException) : base(message, innerException) { }
        public ConfigException(string format, params object[] args) : base(string.Format(format, args)) { }
    }
}
