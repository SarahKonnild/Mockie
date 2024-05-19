using System.Reflection;

namespace Mockie.MethodInvocation;

/// <summary>
///     Defines a method call with all its properties
/// </summary>
public interface IMethodCall
{
    /// <summary>
    ///     Get the method's return type.
    /// </summary>
    /// <returns>The method's return type. Is null if void.</returns>
    public Type? GetReturnType();

    /// <summary>
    ///     Get the method's info.
    /// </summary>
    /// <returns>The method's info.</returns>
    public MethodInfo GetMethodInfo();
    
    /// <summary>
    ///     Get the method's arguments, if any.
    /// </summary>
    /// <returns>A dictionary of arguments passed if there are arguments; empty if none.</returns>
    public Dictionary<ArgumentInfo, object> GetMethodArguments();
}