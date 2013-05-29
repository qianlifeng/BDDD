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