using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace Chrison.Extensions;

public class ArrayExtensionsUnitTests
{
    [Fact]
    public void Add_ShouldAddItemToArray()
    {
        // Arrange
        int[] array = [1, 2, 3];
        int item = 4;

        // Act
        int[] result = array.Add(item);

        // Assert
        int[] expected = [1, 2, 3, 4];
        result.ShouldBe(expected);
    }
}