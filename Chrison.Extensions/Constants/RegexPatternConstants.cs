using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrison.Constants;

public static class RegexPatternConstants
{
    // TODO: Move to a New Zealand specific project
    /// <summary>
    /// Winz SWN Number
    /// </summary>
    /// <example>123-456-789</example>
    public const string SwnNumberPattern = @"([0-9]{3})-([0-9]{3})-([0-9]{3})";

    /// <summary>
    /// Date
    /// </summary>
    /// <example>
    /// 01/01/22
    /// 01/01/2022
    /// </example>
    public const string DatePattern = @"([0-9]{2})/([0-9]{2})/([0-9]{2,4})";

    /// <summary>
    /// Currency
    /// </summary>
    public const string CurrencyPattern = @"(([1-9]\d{0,2}(\,\d{3})*)|([1-9]\d*)|(0))(\.\d{2})";

    /// <summary>
    /// HTML Tags
    /// </summary>
    public const string HtmlTagPattern = @"<[a-zA-Z/].*?>";
}