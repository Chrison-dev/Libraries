using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using TinyHelpers.Extensions;

namespace Chrison.Extensions;

public static class StringExtensions
{
    #region Constructor
    /// <summary>
    /// Registers required Encodings
    /// </summary>
    static StringExtensions()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }
    #endregion

    /// <summary>
    /// Remove all traces of HTML from a string
    /// </summary>
    /// <param name="htmlString"></param>
    /// <returns></returns>
    public static string RemoveHtml(this string htmlString)
    {
        if (string.IsNullOrWhiteSpace(htmlString)) return string.Empty;

        return Regex.Replace(htmlString, Constants.RegexPatternConstants.HtmlTagPattern, string.Empty);
    }

    /// <summary>
    /// Sanitise strings and remove all Diacritics
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    /// <remarks>https://stackoverflow.com/questions/249087/how-do-i-remove-diacritics-accents-from-a-string-in-net</remarks>
    public static string RemoveDiacritics(this string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return string.Empty;

        byte[] tempBytes;
        tempBytes = Encoding.GetEncoding("ISO-8859-8").GetBytes(text);
        return Encoding.UTF8.GetString(tempBytes);
    }

    /// <summary>
    /// Ensure that the input string ends on a slash
    /// </summary>
    /// <param name="inputString"></param>
    /// <returns></returns>
    public static string EnsureTrailingSlash(this string inputString)
    {
        if (string.IsNullOrWhiteSpace(inputString)) return string.Empty;

        if (!inputString.EndsWith("/")) inputString += "/";
        return inputString;
    }

    /// <summary>
    /// Adds a Query Parameter to a URL
    /// </summary>
    /// <param name="url"></param>
    /// <param name="parameter"></param>
    /// <returns></returns>
    /// <remarks>
    /// Ensure that the correct HTML characters are present to add Query Parameters
    /// </remarks>
    public static string AddUrlParameter(this string url, string parameter)
    {
        if (url.IsNullOrEmpty()) return string.Empty;

        if (url.Contains('?'))
            url += "&";
        else
            url += "?";

        url += parameter;

        return url;
    }

    /// <summary>
    /// Extension for string.IsNullOrWhiteSpace()
    /// </summary>
    /// <param name="inputString"></param>
    /// <returns></returns>
    public static bool IsNullOrWhiteSpace(this string inputString) => string.IsNullOrWhiteSpace(inputString);

    /// <summary>
    /// Extension for string.IsNullOrEmpty()
    /// </summary>
    /// <param name="inputString"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty(this string inputString) => string.IsNullOrEmpty(inputString);

    /// <summary>
    /// Convert <see cref="string"/> to <see cref="int"/>
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int ToInt(this string value) => int.TryParse(value, out int result) ? result : 0;

    /// <summary>
    /// Convert <see cref="string"/> to <see cref="decimal"/>
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static decimal ToDecimal(this string value) => decimal.TryParse(value, out decimal result) ? result : decimal.Zero;

    /// <summary>
    /// Convert nullable <see cref="string"/> to nullable <see cref="DateOnly"/>
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static DateOnly? ToNullableDateOnly(this string? input)
    {
        if (input is null || input.IsNullOrEmpty()) return null;

        if (DateOnly.TryParse(input, out DateOnly date)) return date;
        else return null;
    }

    /// <summary>
    /// Convert <see cref="string"/> to <see cref="DateOnly"/>
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static DateOnly ToDateOnly(this string input)
    {
        if (input.IsNullOrEmpty()) throw new ArgumentNullException("Input cannot be null or empty");

        if (DateOnly.TryParse(input, out DateOnly date)) return date;
        else throw new FormatException("Cannot convert input into DateOnly");
    }

    /// <summary>
    /// Convert <see cref="string"/> to <see cref="DateTime"/>
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="FormatException"></exception>
    public static DateTime ToDateTime(this string input)
    {
        if (input.IsNullOrEmpty()) throw new ArgumentNullException("Input cannot be null or empty");

        if (DateTime.TryParse(input, out DateTime dateTime)) return dateTime;
        else throw new FormatException("Cannot convert input into DateTime");
    }

    /// <summary>
    /// Convert String to Boolean
    /// </summary>
    /// <remarks>Automatically catches TRUE values for 1, YES, Y and TRUE</remarks>
    /// <param name="input"></param>
    /// <param name="stringForTrue"></param>
    /// <returns></returns>
    public static bool ToBoolean(this string input, string stringForTrue = "")
    {
        if (input.IsNullOrEmpty()) return false;
        if (!stringForTrue.IsNullOrEmpty()) return string.Equals(input, stringForTrue, StringComparison.InvariantCultureIgnoreCase);

        /* Default Cases for True parsing */
        if (string.Equals(input, "Yes", StringComparison.InvariantCultureIgnoreCase)) return true;
        if (string.Equals(input, "Y", StringComparison.InvariantCultureIgnoreCase)) return true;
        if (string.Equals(input, "1", StringComparison.InvariantCultureIgnoreCase)) return true;
        if (string.Equals(input, "True", StringComparison.InvariantCultureIgnoreCase)) return true;

        return false;
    }

    /// <summary>
    /// Take an Email Address and extract the first bit to make it into a Full Name (assuming this is what the first bit contains)
    /// </summary>
    /// <param name="emailAddress"></param>
    /// <returns></returns>
    public static string ExtractFullNameFromEmailAddress(this string? emailAddress)
    {
        if (emailAddress == null || !emailAddress.Contains('@')) return string.Empty;

        string fullName = emailAddress.Split('@').First();
        if (fullName.Contains('.'))
        {
            string firstName = fullName.Split('.').First().FirstCharToUpper();
            string lastName = fullName.Split('.').Skip(1).First().FirstCharToUpper();
            fullName = firstName + " " + lastName;
        }
        return fullName;
    }
}