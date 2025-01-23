using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrison.Extensions;

public class TimeOnlyExtensionsTests
{
    [Fact]
    public void ToDateTime_ShouldConvertTimeOnlyToDateTime()
    {
        // Arrange
        var time = new TimeOnly(14, 30, 0); // 2:30 PM

        // Act
        var result = time.ToDateTime();

        // Assert
        Assert.Equal(new DateTime(2000, 1, 1, 14, 30, 0), result);
    }

    [Fact]
    public void ToDateTime_ShouldReturnNullForNullTimeOnly()
    {
        // Arrange
        TimeOnly? time = null;

        // Act
        var result = time.ToDateTime();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ToDateTime_ShouldConvertNullableTimeOnlyToDateTime()
    {
        // Arrange
        TimeOnly? time = new TimeOnly(9, 45, 0); // 9:45 AM

        // Act
        var result = time.ToDateTime();

        // Assert
        Assert.Equal(new DateTime(2000, 1, 1, 9, 45, 0), result);
    }
}