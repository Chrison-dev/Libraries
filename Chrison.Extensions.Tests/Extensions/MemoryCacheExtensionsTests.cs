using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Shouldly;

namespace Chrison.Extensions;

public class MemoryCacheExtensionsTests
{
    [Fact]
    public void GetKeys_ShouldReturnAllKeys()
    {
        // Arrange
        var memoryCache = new MemoryCache(new MemoryCacheOptions());
        memoryCache.Set("key1", "value1");
        memoryCache.Set("key2", "value2");

        // Act
        var keys = memoryCache.GetKeys();

        // Assert
        keys.ShouldBe(new[] { "key1", "key2" });
        Assert.Equal(2, ((ICollection)keys).Count);
    }

    [Fact]
    public void GetKeysOfType_ShouldReturnAllKeysOfType()
    {
        // Arrange
        var memoryCache = new MemoryCache(new MemoryCacheOptions());
        memoryCache.Set("key1", "value1");
        memoryCache.Set(2, "value2");

        // Act
        var stringKeys = memoryCache.GetKeys<string>();
        var intKeys = memoryCache.GetKeys<int>();

        // Assert
        Assert.Contains("key1", stringKeys);
        Assert.Contains(2, intKeys);
    }
}