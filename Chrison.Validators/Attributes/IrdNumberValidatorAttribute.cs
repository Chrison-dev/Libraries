using System.ComponentModel.DataAnnotations;
using Chrison.Validators;

namespace Chrison.Attributes;

/// <summary>
/// Validates IRD Numbers against NZ IRD Regulations
/// </summary>
public class IrdNumberValidatorAttribute : ValidationAttribute
{
    /// <summary>
    /// Validate an IRD Number
    /// </summary>
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var validator = new IrdNumberValidator();
        try
        {
            ArgumentNullException.ThrowIfNull(value);

            string irdNumber = (string)value;
            if (validator.IsValid(irdNumber)) return ValidationResult.Success;
            else return new ValidationResult("Invalid IRD number");
        }
        catch (Exception ex)
        {
            return new ValidationResult(ex.Message);
        }
    }
}