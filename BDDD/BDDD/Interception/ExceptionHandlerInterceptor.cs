using System;
using Castle.DynamicProxy;

namespace BDDD.Interception
{
    /// <summary>
    ///     异常拦截器
    /// </summary>
    public class ExceptionHandlerInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                invocation.ReturnValue = GetReturnValueByType(invocation.Method.ReturnType);
                //bool handled = ExceptionManager.HandleException(ex);
                //if (!handled)
                //    throw;
            }
        }

        private object GetReturnValueByType(Type type)
        {
            if (type.IsClass || type.IsInterface)
                return null;
            if (type == typeof (void))
                return null;
            return Activator.CreateInstance(type);
        }
    }
}