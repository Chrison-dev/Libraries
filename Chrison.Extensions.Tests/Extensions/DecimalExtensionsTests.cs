using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrison.Extensions;

public class DecimalExtensionsTests
{
    [Fact]
    public void ToInt_ShouldConvertDecimalToInt()
    {
        // Arrange
        decimal value = 10.5m;

        // Act
        int result = value.ToInt();

        // Assert
        Assert.Equal(10, result);
    }

    [Fact]
    public void ToInt_ShouldConvertNegativeDecimalToInt()
    {
        // Arrange
        decimal value = -10.5m;

        // Act
        int result = value.ToInt();

        // Assert
        Assert.Equal(-10, result);
    }

    [Fact]
    public void ToInt_ShouldConvertZeroDecimalToInt()
    {
        // Arrange
        decimal value = 0m;

        // Act
        int result = value.ToInt();

        // Assert
        Assert.Equal(0, result);
    }
}