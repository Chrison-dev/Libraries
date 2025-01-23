using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrison.Extensions;

/// <summary>
/// Extensions for <see cref="decimal"/>
/// </summary>
public static class DecimalExtensions
{
    /// <summary>
    /// Converts to <see cref="int"/>
    /// </summary>
    public static int ToInt(this decimal d) => (int)d;
}