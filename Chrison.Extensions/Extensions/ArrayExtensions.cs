namespace Chrison.Extensions;

public static class ArrayExtensions
{
    /// <summary>
    /// Add item to array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    /// <remarks>
    /// https://stackoverflow.com/questions/202813/adding-values-to-a-c-sharp-array
    /// </remarks>
    public static T[] Add<T>(this T[] array, T item)
    {
        array ??= []; // Initialise Array if needed

        T[] result = new T[array.Length + 1];
        array.CopyTo(result, 0);
        result[array.Length] = item;
        return result;
    }
}