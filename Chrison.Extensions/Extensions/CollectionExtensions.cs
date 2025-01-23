using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic;

public static class CollectionExtensions
{
    /// <summary>
    /// Adds a range of items to the collection.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="collection">The collection to add items to.</param>
    /// <param name="items">The items to add to the collection.</param>
    public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
    {
        // If the collection is a List<T>, use the AddRange method for better performance.
        if (collection is List<T> list)
        {
            list.AddRange(items);
            return;
        }

        // Otherwise, add each item individually.
        foreach (T item in items)
        {
            collection.Add(item);
        }
    }
}
