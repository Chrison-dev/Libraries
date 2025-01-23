using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrison.Extensions;

public class StringExtensionsTests
{
    [Fact]
    public void RemoveHtml_ShouldRemoveHtmlTags()
    {
        string input = "<p>This is a <strong>test</strong>.</p>";
        string expected = "This is a test.";
        string result = input.RemoveHtml();
        Assert.Equal(expected, result);
    }

    [Fact]
    public void RemoveDiacritics_ShouldRemoveDiacritics()
    {
        string input = "café";
        string expected = "cafe";
        string result = input.RemoveDiacritics();
        Assert.Equal(expected, result);
    }

    [Fact]
    public void EnsureTrailingSlash_ShouldAddSlashIfNotPresent()
    {
        string input = "http://example.com";
        string expected = "http://example.com/";
        string result = input.EnsureTrailingSlash();
        Assert.Equal(expected, result);
    }

    [Fact]
    public void EnsureTrailingSlash_ShouldNotAddSlashIfPresent()
    {
        string input = "http://example.com/";
        string expected = "http://example.com/";
        string result = input.EnsureTrailingSlash();
        Assert.Equal(expected, result);
    }

    [Fact]
    public void AddUrlParameter_ShouldAddParameterToUrl()
    {
        string url = "http://example.com";
        string parameter = "param=value";
        string expected = "http://example.com?param=value";
        string result = url.AddUrlParameter(parameter);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void IsNullOrWhiteSpace_ShouldReturnTrueForNullOrWhiteSpace()
    {
        string input = " ";
        bool result = input.IsNullOrWhiteSpace();
        Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_ShouldReturnTrueForNullOrEmpty()
    {
        string input = "";
        bool result = input.IsNullOrEmpty();
        Assert.True(result);
    }

    [Fact]
    public void ToInt_ShouldConvertStringToInt()
    {
        string input = "123";
        int expected = 123;
        int result = input.ToInt();
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToDecimal_ShouldConvertStringToDecimal()
    {
        string input = "123.45";
        decimal expected = 123.45m;
        decimal result = input.ToDecimal();
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToNullableDateOnly_ShouldConvertStringToNullableDateOnly()
    {
        string input = "2023-10-10";
        DateOnly? expected = new DateOnly(2023, 10, 10);
        DateOnly? result = input.ToNullableDateOnly();
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToDateOnly_ShouldConvertStringToDateOnly()
    {
        string input = "2023-10-10";
        DateOnly expected = new DateOnly(2023, 10, 10);
        DateOnly result = input.ToDateOnly();
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToDateTime_ShouldConvertStringToDateTime()
    {
        string input = "2023-10-10T10:10:10";
        DateTime expected = new DateTime(2023, 10, 10, 10, 10, 10);
        DateTime result = input.ToDateTime();
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToBoolean_ShouldConvertStringToBoolean()
    {
        string input = "True";
        bool result = input.ToBoolean();
        Assert.True(result);
    }

    [Fact]
    public void ExtractFullNameFromEmailAddress_ShouldExtractFullName()
    {
        string input = "john.doe@example.com";
        string expected = "John Doe";
        string result = input.ExtractFullNameFromEmailAddress();
        Assert.Equal(expected, result);
    }
}