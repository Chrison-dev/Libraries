namespace System;

/// <summary>
/// Extensions for <see cref="int"/>
/// </summary>
public static class IntegerExtensions
{
    /// <summary>
    /// Separates a number out into its individual digits
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static int[] ToDigitArray(this int number)
    {
        string numberString = number.ToString();
        var charArray = numberString.ToCharArray();
        int[] numArray = new int[charArray.Length];
        for (int i = 0; i < charArray.Length; i++) numArray[i] = int.Parse($"{charArray[i]}");
        return numArray;
    }
}