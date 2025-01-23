using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrison.Extensions;

public class CollectionExtensionsTests
{
    [Fact]
    public void AddRange_AddsItemsToList()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3 };
        var itemsToAdd = new List<int> { 4, 5, 6 };

        // Act
        list.AddRange(itemsToAdd);

        // Assert
        Assert.Equal(6, list.Count);
        Assert.Contains(4, list);
        Assert.Contains(5, list);
        Assert.Contains(6, list);
    }

    [Fact]
    public void AddRange_AddsItemsToCollection()
    {
        // Arrange
        ICollection<int> collection = new HashSet<int> { 1, 2, 3 };
        var itemsToAdd = new List<int> { 4, 5, 6 };

        // Act
        collection.AddRange(itemsToAdd);

        // Assert
        Assert.Equal(6, collection.Count);
        Assert.Contains(4, collection);
        Assert.Contains(5, collection);
        Assert.Contains(6, collection);
    }

    [Fact]
    public void AddRange_DoesNotAddDuplicateItemsToHashSet()
    {
        // Arrange
        ICollection<int> collection = new HashSet<int> { 1, 2, 3 };
        var itemsToAdd = new List<int> { 3, 4, 5 };

        // Act
        collection.AddRange(itemsToAdd);

        // Assert
        Assert.Equal(5, collection.Count);
        Assert.Contains(3, collection);
        Assert.Contains(4, collection);
        Assert.Contains(5, collection);
    }
}