using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;

namespace Chrison.Validators;

/// <summary>
/// Validates IRD numbers
/// </summary>
/// <remarks>
/// https://www.ird.govt.nz/-/media/project/ir/home/documents/income-tax/withholding-taxes/rwt-nrwt-withholding-tax-certificate/2020-rwt-and-nrwt-certificate-filing-specification.pdf?modified=20201016012133
/// </remarks>
public class IrdNumberValidator() : IValidator<string>
{
    #region Methods
    /// <summary>
    /// Validates if a IRD number as a string is valid
    /// </summary>
    /// <param name="irdNumber"></param>
    /// <returns>True if valid</returns>
    public bool IsValid(string irdNumber)
    {
        if (irdNumber is null) return false;
        if (string.IsNullOrWhiteSpace(irdNumber)) return false;

        try
        {
            irdNumber = irdNumber.Replace(" ", "");
            irdNumber = irdNumber.Replace("-", "");
            return IsValid(int.Parse(irdNumber));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{irdNumber} is not a number", ex);
            return false;
        }
    }

    /// <summary>
    /// Validates if an IRD number as an INT is valid
    /// </summary>
    /// <param name="irdNumber"></param>
    /// <returns>True if valid</returns>
    public bool IsValid(int irdNumber)
    {
        bool lengthCheck = irdNumber >= 010000000 && irdNumber <= 150000000;
        if (!lengthCheck) return false;

        int[] digits = irdNumber.ToDigitArray(); // Resolve dependency via Nuget Package Chrison.Extensions
        int checkDigit = digits.Last();
        int[] validationDigits = new int[digits.Length - 1];

        for (int index = 0; index < digits.Length - 1; index++) validationDigits[index] = digits[index];
        int calculatedCheckDigit = CalculateCheckDigit(validationDigits);

        return calculatedCheckDigit == checkDigit;
    }

    /// <summary>
    /// Calculate the correct check digit for NZ IRD Numbers
    /// </summary>
    /// <param name="digits"></param>
    /// <returns>Check Digit</returns>
    public int CalculateCheckDigit(int[] digits)
    {
        //int[] digits = number.ToDigitArray();
        int[] baseNumbers = [0, 0, 0, 0, 0, 0, 0, 0];
        int[] weightFactors = [3, 2, 7, 6, 5, 4, 3, 2];

        int baseNumbersIndex = baseNumbers.Length - 1;
        /* Parse into base numbers, padding zero at the left if short IRD */
        for (int index = digits.Length - 1; index >= 0; index--)
        {
            baseNumbers[baseNumbersIndex] = digits[index];
            baseNumbersIndex--;
        }

        /* Calculate weight */
        for (int index = baseNumbers.Length - 1; index >= 0; index--)
        {
            baseNumbers[index] *= weightFactors[index];
        }

        /* Sum */
        int sum = 0;
        foreach (int num in baseNumbers) sum += num;

        /* Divide by 11 */
        int remainder = sum % 11;

        /* If result is zero, Check Digit is 0 */
        if (remainder == 0) return 0;

        /* Else, substract remainder from 11 */
        remainder = 11 - remainder;

        /* if 0-9 then this is the Check Digit */
        if (remainder < 10) return remainder;

        /* if 10 then re-calculate */
        return RecalculateCheckDigit(digits);
    }

    public int RecalculateCheckDigit(int[] digits)
    {
        int[] baseNumbers = [0, 0, 0, 0, 0, 0, 0, 0];
        int[] weightFactors = [7, 4, 3, 2, 5, 2, 7, 6];

        int baseNumbersIndex = baseNumbers.Length - 1;
        /* Parse into base numbers, padding zero at the left if short IRD */
        for (int index = digits.Length - 1; index >= 0; index--)
        {
            baseNumbers[baseNumbersIndex] = digits[index];
            baseNumbersIndex--;
        }

        /* Calculate weight */
        for (int index = baseNumbers.Length - 1; index >= 0; index--)
        {
            baseNumbers[index] *= weightFactors[index];
        }

        /* Sum */
        int sum = 0;
        foreach (int num in baseNumbers) sum += num;

        int remainder = sum % 11;
        if (remainder == 0) return remainder;
        if (remainder == 10) throw new Exceptions.IrdNumberHasInvalidCheckDigitException();
        return 11 - remainder;
    }
    #endregion
}