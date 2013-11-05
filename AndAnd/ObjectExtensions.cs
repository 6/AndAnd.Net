using Castle.DynamicProxy;

namespace AndAnd
{
    public static class ObjectExtensions
    {
        private static readonly ProxyGenerator proxyGenerator = new ProxyGenerator();

        public static T AndAnd<T>(this T obj) where T : class
        {
            if (obj == null)
            {
                if (typeof (T).IsInterface)
                {
                    return proxyGenerator.CreateInterfaceProxyWithoutTarget<T>(new ParameterInterceptor());
                }
                return proxyGenerator.CreateClassProxy<T>(new ParameterInterceptor());
            }
            return obj;
        }
    }

    public class ParameterInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.ReturnValue = null;
        }
    }
}
