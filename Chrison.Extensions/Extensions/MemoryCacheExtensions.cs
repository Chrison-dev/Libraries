using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Chrison.Extensions;

// TODO: Move into its own project Chrison.Extensions.MemoryCache
/// <summary>
/// Extensions for <see cref="MemoryCache"/>
/// </summary>
public static class MemoryCacheExtensions
{
    #region Get all Keys
    // https://stackoverflow.com/questions/45597057/how-to-retrieve-a-list-of-memory-cache-keys-in-asp-net-core
#pragma warning disable CS8601 // Possible null reference assignment.
    private static readonly Func<MemoryCache, object> GetEntriesCollection = Delegate.CreateDelegate(
        typeof(Func<MemoryCache, object>),
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
        typeof(MemoryCache).GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance).GetGetMethod(true),
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        throwOnBindFailure: true) as Func<MemoryCache, object>;
#pragma warning restore CS8601 // Possible null reference assignment.

    /// <summary>
    /// Get all Keys from a <see cref="IMemoryCache"/>
    /// </summary>
    /// <param name="memoryCache"></param>
    /// <returns></returns>
    public static IEnumerable GetKeys(this MemoryCache memoryCache) =>
        ((IDictionary)GetEntriesCollection(memoryCache)).Keys;

    /// <summary>
    /// Get all Keys from a <see cref="IMemoryCache"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="memoryCache"></param>
    /// <returns></returns>
    public static IEnumerable<T> GetKeys<T>(this MemoryCache memoryCache) =>
        GetKeys(memoryCache).OfType<T>();
    #endregion
}