using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Castle.DynamicProxy;

namespace BDDD.Tests.Interceptions
{
    public class TestInterceptor : IInterceptor
    {
        public static int execCount = 0;

        public void Intercept(IInvocation invocation)
        {
            execCount++;
            invocation.Proceed();
        }
    }
}
