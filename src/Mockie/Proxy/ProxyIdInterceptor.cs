using System.Globalization;
using System.Reflection;
using Castle.DynamicProxy;

namespace Mockie.Proxy;

/// <summary>
///     Intercept the ID of the object/type that's coming in, to give it special naming to display it's Mockie-nature.
/// </summary>
/// <typeparam name="TProxyType">The type being proxied</typeparam>
internal class ProxyIdInterceptor<TProxyType> : IInterceptor where TProxyType : class
{
    // TODO could be a dictionary of IDs with the proxied type? or would that maybe clash with wanting to generate mutliple classes
    private string? _cachedId;

    /// <inheritdoc />
    public void Intercept(IInvocation invocation)
    {
        // If we have a default ToString call, we want to intercept the call and instead give a proxy ID
        if (IsDefaultToStringCall(invocation.Method))
        {
            invocation.ReturnValue = _cachedId ??= GenerateNewProxyId(invocation);
        }
        // If it's not a default ToString call, proceed with the implementation/substituted logic return
        invocation.Proceed();
    }

    private string GenerateNewProxyId(IInvocation invocation)
    {
        var proxy = invocation.InvocationTarget;
        var shortName = typeof(TProxyType).Name;
        var hash = proxy.GetHashCode();
        return string.Format(CultureInfo.InvariantCulture, "Mockie.{0}|{1:x8}", shortName, hash);
    }

    private static bool IsDefaultToStringCall(MethodInfo methodInvocation)
    {
        return methodInvocation.DeclaringType == typeof(object)
               && string.Equals(methodInvocation.Name, nameof(ToString), StringComparison.Ordinal)
               && methodInvocation.GetParameters().Length == 0;
    }
}