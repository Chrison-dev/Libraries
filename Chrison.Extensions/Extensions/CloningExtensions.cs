using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Chrison.Extensions;

/// <summary>
/// https://stackoverflow.com/questions/78536/deep-cloning-objects
/// </summary>
public static class CloningExtensions
{
    /// <summary>
    /// Perform a shallow Copy of the object.
    /// </summary>
    /// <typeparam name="T">The type of object being copied.</typeparam>
    /// <param name="source">The object instance to copy.</param>
    /// <returns>The copied object.</returns>
    public static T? ShallowClone<T>(this T source)
    {
        // Don't serialize a null object, simply return the default for that object
        if (source is null) return default;

        var methodInfo = typeof(T).GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);
        if (methodInfo is null) return default;

        var result = methodInfo.Invoke(source, null);
        if (result == null) return default;

        return (T)result;
    }

    /// <summary>
    /// Perform a deep Copy of the object, using Json as a serialisation method. NOTE: Private members are not cloned using this method.
    /// </summary>
    /// <typeparam name="T">The type of object being copied.</typeparam>
    /// <param name="source">The object instance to copy.</param>
    /// <returns>The copied object.</returns>
    public static T? DeepCloneJson<T>(this T source)
    {
        // Don't serialize a null object, simply return the default for that object
        if (source is null) return default;

        return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(source));
    }
}