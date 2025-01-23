using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrison.Extensions;

public class EnumExtensionsTests
{
    private enum TestEnum
    {
        [Display(Name = "First Value", Description = "First Value Description")]
        FirstValue,
        [Display(Name = "Second Value", Description = "Second Value Description")]
        SecondValue,
        ThirdValue // No Display attribute
    }

    [Fact]
    public void GetDisplayName_ShouldReturnDisplayName_WhenDisplayAttributeIsPresent()
    {
        // Arrange
        var enumValue = TestEnum.FirstValue;

        // Act
        var displayName = enumValue.GetDisplayName();

        // Assert
        Assert.Equal("First Value", displayName);
    }

    [Fact]
    public void GetDisplayName_ShouldReturnEnumName_WhenDisplayAttributeIsNotPresent()
    {
        // Arrange
        var enumValue = TestEnum.ThirdValue;

        // Act
        var displayName = enumValue.GetDisplayName();

        // Assert
        Assert.Equal("ThirdValue", displayName);
    }

    [Fact]
    public void GetDescription_ShouldReturnDescription_WhenDisplayAttributeIsPresent()
    {
        // Arrange
        var enumValue = TestEnum.SecondValue;

        // Act
        var description = enumValue.GetDescription();

        // Assert
        Assert.Equal("Second Value Description", description);
    }

    [Fact]
    public void GetDescription_ShouldReturnEnumName_WhenDisplayAttributeIsNotPresent()
    {
        // Arrange
        var enumValue = TestEnum.ThirdValue;

        // Act
        var description = enumValue.GetDescription();

        // Assert
        Assert.Equal("ThirdValue", description);
    }
}