using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace BDDD.Repository
{
    /// <summary>
    /// 发生在BDDD框架中的Repository异常
    /// </summary>
    [Serializable]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(_Exception))]
    public class RepositoryException : BDDDException
    {
        public RepositoryException() : base() { }
        public RepositoryException(string message) : base(message) { }
        public RepositoryException(string message, Exception innerException) : base(message, innerException) { }
        public RepositoryException(string format, params object[] args) : base(string.Format(format, args)) { }
    }
}
