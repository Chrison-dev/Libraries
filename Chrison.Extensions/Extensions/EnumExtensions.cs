using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chrison.Extensions;

/// <summary>
/// Extensions for <see cref="Enum"/>
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Get the Name attribute for an enum
    /// </summary>
    /// <param name="enumValue"></param>
    /// <returns></returns>
    public static string GetDisplayName(this Enum enumValue)
    {
        string? displayName;
#pragma warning disable CS8604 // Possible null reference argument.
        displayName = enumValue.GetType()
            .GetMember(enumValue.ToString())
            .FirstOrDefault()
            .GetCustomAttribute<DisplayAttribute>()?
            .GetName();
#pragma warning restore CS8604 // Possible null reference argument.
        if (string.IsNullOrWhiteSpace(displayName))
        {
            displayName = enumValue.ToString();
        }
        return displayName;
    }

    /// <summary>
    /// Get the Description value for an enum
    /// </summary>
    /// <param name="enumValue"></param>
    /// <returns></returns>
    public static string GetDescription(this Enum enumValue)
    {
        string? description;
#pragma warning disable CS8604 // Possible null reference argument.
        description = enumValue.GetType()
            .GetMember(enumValue.ToString())
            .FirstOrDefault()
            .GetCustomAttribute<DisplayAttribute>()?
            .GetDescription();
#pragma warning restore CS8604 // Possible null reference argument.
        if (string.IsNullOrWhiteSpace(description))
        {
            description = enumValue.ToString();
        }
        return description;
    }
}