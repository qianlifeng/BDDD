using System;
using System.Runtime.InteropServices;

namespace BDDD
{
    /// <summary>
    ///     代表了所有发生在BDDD框架中的异常
    /// </summary>
    [Serializable]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof (_Exception))]
    public class BDDDException : Exception
    {
        public BDDDException()
        {
        }

        public BDDDException(string message) : base(message)
        {
        }

        public BDDDException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BDDDException(string format, params object[] args) : base(string.Format(format, args))
        {
        }
    }
}