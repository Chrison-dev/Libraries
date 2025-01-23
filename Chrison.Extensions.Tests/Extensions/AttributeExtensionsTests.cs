using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace Chrison.Extensions;

public class AttributeExtensionsTests
{
    private class TestClass
    {
        public string TestProperty { get; set; } = string.Empty;
    }

    [Fact]
    public void GetProperty_ShouldReturnPropertyInfo()
    {
        // Arrange
        Expression<Func<TestClass, object?>> expression = x => x.TestProperty;

        // Act
        PropertyInfo propertyInfo = AttributeExtensions.GetProperty(expression);

        // Assert
        propertyInfo.ShouldNotBeNull();
        propertyInfo.Name.ShouldBe("TestProperty");
    }
}