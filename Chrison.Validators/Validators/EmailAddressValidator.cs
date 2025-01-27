using System.Text.RegularExpressions;

namespace Chrison.Validators;

// TODO: Rewrite and then do Unit Tests with DI support
/// <summary>
/// Validates Email Addresses according to RFC
/// </summary>
/// <remarks>https://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx/</remarks>
public class EmailAddressValidator() : IValidator<string>
{
    #region Methods
    /// <summary>
    /// Validates if an Email Address is valid
    /// </summary>
    /// <param name="emailAddress"></param>
    /// <returns>True if valid</returns>
    public bool IsValid(string emailAddress)
    {
        if (emailAddress is null) return false;
        if (string.IsNullOrWhiteSpace(emailAddress)) return false;

        string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

        Regex regex = new(pattern, RegexOptions.IgnoreCase);

        return regex.IsMatch(emailAddress);
    }
    #endregion
}
