using System.Linq.Expressions;
using System.Reflection;

namespace Chrison.Extensions;

/// <summary>
/// Extensions for Attributes
/// </summary>
public static class AttributeExtensions
{
    private static PropertyInfo GetPropertyInternal(LambdaExpression p)
    {
        MemberExpression memberExpression;

        if (p.Body is UnaryExpression ue)
        {
            memberExpression = (MemberExpression)ue.Operand;
        }
        else
        {
            memberExpression = (MemberExpression)p.Body;
        }
        return (PropertyInfo)(memberExpression).Member;
    }

    /// <summary>
    /// Get Property
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    /// <param name="p"></param>
    /// <returns></returns>
    public static PropertyInfo GetProperty<TObject>(Expression<Func<TObject, object?>> p) => GetPropertyInternal(p);
}