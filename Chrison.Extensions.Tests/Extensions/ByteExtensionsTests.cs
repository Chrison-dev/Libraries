using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace Chrison.Extensions;

public class ByteExtensionsTests
{
    [Fact]
    public void EncodeToBase64Bytes_ShouldEncodeAndDecodeCorrectly()
    {
        // Arrange
        byte[] rawData = [1, 2, 3, 4, 5];

        // Act
        byte[] result = rawData.EncodeToBase64Bytes();

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBe(rawData);
    }
}