using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace Chrison.Validators;

public class EmailAddressValidatorUnitTests
{
    [Theory]
    [InlineData("test@example.com", true)]
    [InlineData("user.name+tag+sorting@example.com", true)]
    [InlineData("user.name@example.co.uk", true)]
    [InlineData("user.name@sub.example.com", true)]
    [InlineData("user@localserver", false)]
    [InlineData("user@.com", false)]
    [InlineData("user@com", false)]
    [InlineData("user@-example.com", false)]
    [InlineData("user@.example.com", false)]
    [InlineData("user@exam_ple.com", false)] // TODO: Fix this
    [InlineData("", false)]
    [InlineData(null, false)]
    public void IsValid_ShouldValidateEmailAddresses(string emailAddress, bool expected)
    {
        // Arrange
        var _validator = new EmailAddressValidator();

        // Act
        var result = _validator.IsValid(emailAddress);

        // Assert
        result.ShouldBe(expected, $"{emailAddress}");
    }
}
