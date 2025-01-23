using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrison.Extensions;

public static class TypeExtensions
{
    /// <summary>
    /// Check if Interface has been implemented
    /// </summary>
    /// <param name="type"></param>
    /// <param name="interfaceType"></param>
    /// <returns></returns>
    public static bool HasInterface(this Type type, Type interfaceType)
    {
        return type.GetInterfacesOf(interfaceType).Length > 0;
    }

    /// <summary>
    /// Get all implemented Interfaces
    /// </summary>
    /// <param name="type"></param>
    /// <param name="interfaceType"></param>
    /// <returns></returns>
    public static Type[] GetInterfacesOf(this Type type, Type interfaceType)
    {
        return type.FindInterfaces((i, _) => i.GetGenericTypeDefinitionSafe() == interfaceType, null);
    }

    public static Type GetGenericTypeDefinitionSafe(this Type type)
    {
        return type.IsGenericType
            ? type.GetGenericTypeDefinition()
            : type;
    }
}