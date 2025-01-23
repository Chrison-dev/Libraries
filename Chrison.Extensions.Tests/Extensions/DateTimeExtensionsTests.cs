using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyHelpers.Extensions;

namespace Chrison.Extensions;

public class DateTimeExtensionsTests
{
    [Fact]
    public void SubstractMonths_ShouldReturnCorrectDate()
    {
        var date = new DateTime(2023, 10, 15);
        var result = date.SubstractMonths(2);
        Assert.Equal(new DateTime(2023, 8, 15), result);
    }

    [Fact]
    public void SubstractDays_ShouldReturnCorrectDate()
    {
        var date = new DateTime(2023, 10, 15);
        var result = date.SubstractDays(10);
        Assert.Equal(new DateTime(2023, 10, 5), result);
    }

    [Fact]
    public void IsInThePast_ShouldReturnTrueForPastDate()
    {
        var date = DateTime.Now.AddDays(-1);
        var result = date.IsInThePast();
        Assert.True(result);
    }

    [Fact]
    public void IsInThePast_ShouldReturnFalseForFutureDate()
    {
        var date = DateTime.Now.AddDays(1);
        var result = date.IsInThePast();
        Assert.False(result);
    }

    [Fact]
    public void IsInTheFuture_ShouldReturnTrueForFutureDate()
    {
        var date = DateTime.Now.AddDays(1);
        var result = date.IsInTheFuture();
        Assert.True(result);
    }

    [Fact]
    public void IsInTheFuture_ShouldReturnFalseForPastDate()
    {
        var date = DateTime.Now.AddDays(-1);
        var result = date.IsInTheFuture();
        Assert.False(result);
    }

    [Fact]
    public void IsToday_ShouldReturnTrueForTodayDate()
    {
        var date = DateTime.Today;
        var result = date.IsToday();
        Assert.True(result);
    }

    [Fact]
    public void IsToday_ShouldReturnFalseForNonTodayDate()
    {
        var date = DateTime.Today.AddDays(-1);
        var result = date.IsToday();
        Assert.False(result);
    }

    [Fact]
    public void ToDateOnly_ShouldReturnDateOnly()
    {
        var dateTime = new DateTime(2023, 10, 15, 10, 30, 0);
        var result = dateTime.ToDateOnly();
        Assert.Equal(new DateOnly(2023, 10, 15), result);
    }

    [Fact]
    public void ToDateOnly_ShouldReturnNullForNullDateTime()
    {
        DateTime? dateTime = null;
        var result = dateTime.ToDateOnly();
        Assert.Null(result);
    }

    [Fact]
    public void ToTimeOnly_ShouldReturnTimeOnly()
    {
        var dateTime = new DateTime(2023, 10, 15, 10, 30, 0);
        var result = dateTime.ToTimeOnly();
        Assert.Equal(new TimeOnly(10, 30), result);
    }

    [Fact]
    public void ToTimeOnly_ShouldReturnNullForNullDateTime()
    {
        DateTime? dateTime = null;
        var result = dateTime.ToTimeOnly();
        Assert.Null(result);
    }
}