using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrison.Extensions;

public class TypeExtensionsTests
{
    public interface ITestInterface { }
    public class TestClass : ITestInterface { }
    public class NonGenericClass { }
    public class GenericClass<T> : ITestInterface { }

    [Fact]
    public void HasInterface_ShouldReturnTrue_WhenInterfaceIsImplemented()
    {
        // Arrange
        var type = typeof(TestClass);
        var interfaceType = typeof(ITestInterface);

        // Act
        var result = type.HasInterface(interfaceType);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HasInterface_ShouldReturnFalse_WhenInterfaceIsNotImplemented()
    {
        // Arrange
        var type = typeof(NonGenericClass);
        var interfaceType = typeof(ITestInterface);

        // Act
        var result = type.HasInterface(interfaceType);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetInterfacesOf_ShouldReturnImplementedInterfaces()
    {
        // Arrange
        var type = typeof(TestClass);
        var interfaceType = typeof(ITestInterface);

        // Act
        var result = type.GetInterfacesOf(interfaceType);

        // Assert
        Assert.Contains(interfaceType, result);
    }

    [Fact]
    public void GetInterfacesOf_ShouldReturnEmptyArray_WhenInterfaceIsNotImplemented()
    {
        // Arrange
        var type = typeof(NonGenericClass);
        var interfaceType = typeof(ITestInterface);

        // Act
        var result = type.GetInterfacesOf(interfaceType);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetGenericTypeDefinitionSafe_ShouldReturnGenericTypeDefinition_WhenTypeIsGeneric()
    {
        // Arrange
        var type = typeof(GenericClass<>);

        // Act
        var result = type.GetGenericTypeDefinitionSafe();

        // Assert
        Assert.Equal(type, result);
    }

    [Fact]
    public void GetGenericTypeDefinitionSafe_ShouldReturnSameType_WhenTypeIsNotGeneric()
    {
        // Arrange
        var type = typeof(NonGenericClass);

        // Act
        var result = type.GetGenericTypeDefinitionSafe();

        // Assert
        Assert.Equal(type, result);
    }
}