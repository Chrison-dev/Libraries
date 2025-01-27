using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrison.Validators;

/// <summary>
/// Generic Validator interface
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IValidator<T>
{
    /// <summary>
    /// Determines if <paramref name="value"/> is valid
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    bool IsValid(T value);
}