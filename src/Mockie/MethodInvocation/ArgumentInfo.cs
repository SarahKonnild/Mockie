namespace Mockie.MethodInvocation;

public readonly struct ArgumentInfo
{
    /// <summary>
    ///     The type of the argument.
    /// </summary>
    public Type Type { get; }

    /// <summary>
    ///     Indicates if the argument is optional.
    /// </summary>
    public bool IsOptional { get; }

    /// <summary>
    ///     Indicates if the argument is an out variable.
    /// </summary>
    public bool IsOut { get; }

    /// <summary>
    ///     The default value set for the argument. Is null if none set.
    /// </summary>
    public object? DefaultValue { get; }

    /// <summary>
    ///     Constructs an ArgumentInfo struct, describing the properties of an argument.
    /// </summary>
    /// <param name="type">The type of the argument.</param>
    /// <param name="isOptional">Indicates if the argument is optional.</param>
    /// <param name="isOut">Indicates if the argument is an out type.</param>
    /// <param name="defaultValue">Describes the default value if one is set. It defaults to null, i.e. none set.</param>
    public ArgumentInfo(Type type, bool isOptional, bool isOut, object? defaultValue = null)
    {
        Type = type;
        IsOptional = IsOptional;
        IsOut = IsOut;
        DefaultValue = DefaultValue;
    }
}