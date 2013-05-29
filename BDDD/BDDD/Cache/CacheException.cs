using System;

namespace BDDD.Cache
{
    public class CacheException : BDDDException
    {
        public CacheException()
        {
        }

        public CacheException(string message) : base(message)
        {
        }

        public CacheException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public CacheException(string format, params object[] args) : base(string.Format(format, args))
        {
        }
    }
}