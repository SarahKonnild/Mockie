using Castle.DynamicProxy;
using Mockie.MethodCall;
using Mockie.Proxy;

namespace Mockie.Factories;

public class DynamicProxyFactory(IMethodCallFactory methodCallFactory)
{
    private readonly ProxyGenerator _proxyGenerator = new();

    /// <summary>
    ///     
    /// </summary>
    /// <param name="methodInvocationDirector"></param>
    /// <param name="interfaces"></param>
    /// <param name="constructorArguments"></param>
    /// <returns></returns>
    // TODO cleanup the object[] usages, don't like iterating ambiguous object arrays where anything can be in it.
    public object GenerateDynamicProxy<TType>(IMethodInvocationDirector methodInvocationDirector,
        Type[]? interfaces = null, object?[]? constructorArguments = null) where TType : class
    {
        // TODO figure out if we want to handle classes having multiple interfaces.
        // TODO constructor arguments? yay or nay?

        // intercept the ID creation for the object
        var proxyIdInterceptor = new ProxyIdInterceptor<TType>();
        return new object();
    }

}