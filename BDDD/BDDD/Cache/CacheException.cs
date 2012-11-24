using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD.Cache
{
    public class CacheException : BDDDException
    {
        public CacheException() : base() { }
        public CacheException(string message) : base(message) { }
        public CacheException(string message, Exception innerException) : base(message, innerException) { }
        public CacheException(string format, params object[] args) : base(string.Format(format, args)) { }

    }
}
