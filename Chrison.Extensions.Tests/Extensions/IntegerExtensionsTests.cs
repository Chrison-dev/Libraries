namespace Chrison.Extensions;

public class IntegerExtensionsTests
{
    [Theory]
    [InlineData(123, new int[] { 1, 2, 3 })]
    [InlineData(0, new int[] { 0 })]
    [InlineData(456789, new int[] { 4, 5, 6, 7, 8, 9 })]
    [InlineData(1001, new int[] { 1, 0, 0, 1 })]
    // Assuming negative numbers should be handled
    // Negative numbers are not supported
    // TODO: Handle negative numbers
    // [InlineData(-123, new int[] { -1, 2, 3 })]
    public void ToDigitArray_ShouldReturnCorrectDigitArray(int number, int[] expected)
    {
        // Act
        var result = number.ToDigitArray();

        // Assert
        Assert.Equal(expected, result);
    }
}