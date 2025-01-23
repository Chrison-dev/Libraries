using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrison.Extensions;

public class DateOnlyExtensionsTests
{
    [Fact]
    public void ToDateTime_ShouldConvertDateOnlyToDateTime()
    {
        var dateOnly = new DateOnly(2023, 10, 5);
        var expectedDateTime = new DateTime(2023, 10, 5);

        var result = dateOnly.ToDateTime();

        Assert.Equal(expectedDateTime, result);
    }

    [Fact]
    public void ToDateTime_ShouldConvertNullableDateOnlyToNullableDateTime()
    {
        DateOnly? dateOnly = new DateOnly(2023, 10, 5);
        DateTime? expectedDateTime = new DateTime(2023, 10, 5);

        var result = dateOnly.ToDateTime();

        Assert.Equal(expectedDateTime, result);
    }

    [Fact]
    public void ToDateTime_ShouldReturnNullForNullDateOnly()
    {
        DateOnly? dateOnly = null;

        var result = dateOnly.ToDateTime();

        Assert.Null(result);
    }

    [Fact]
    public void IsInTheFuture_ShouldReturnTrueForFutureDate()
    {
        var dateOnly = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

        var result = dateOnly.IsInTheFuture();

        Assert.True(result);
    }

    [Fact]
    public void IsInTheFuture_ShouldReturnFalseForPastOrTodayDate()
    {
        var pastDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));
        var todayDate = DateOnly.FromDateTime(DateTime.Today);

        Assert.False(pastDate.IsInTheFuture());
        Assert.False(todayDate.IsInTheFuture());
    }

    [Fact]
    public void IsInTheFuture_ShouldReturnTrueForNullDate()
    {
        DateOnly? dateOnly = null;

        var result = dateOnly.IsInTheFuture();

        Assert.True(result);
    }

    [Fact]
    public void IsInThePresent_ShouldReturnTrueForTodayOrFutureDate()
    {
        var todayDate = DateOnly.FromDateTime(DateTime.Today);
        var futureDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

        Assert.True(todayDate.IsInThePresent());
        Assert.True(futureDate.IsInThePresent());
    }

    [Fact]
    public void IsInThePresent_ShouldReturnFalseForPastDate()
    {
        var pastDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));

        var result = pastDate.IsInThePresent();

        Assert.False(result);
    }

    [Fact]
    public void IsInThePresent_ShouldReturnTrueForNullDate()
    {
        DateOnly? dateOnly = null;

        var result = dateOnly.IsInThePresent();

        Assert.True(result);
    }

    [Fact]
    public void IsToday_ShouldReturnTrueForTodayDate()
    {
        var todayDate = DateOnly.FromDateTime(DateTime.Today);

        var result = todayDate.IsToday();

        Assert.True(result);
    }

    [Fact]
    public void IsToday_ShouldReturnFalseForNonTodayDate()
    {
        var nonTodayDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

        var result = nonTodayDate.IsToday();

        Assert.False(result);
    }

    [Fact]
    public void IsToday_ShouldReturnTrueForNullDate()
    {
        DateOnly? dateOnly = null;

        var result = dateOnly.IsToday();

        Assert.True(result);
    }

    [Fact]
    public void IsInThePast_ShouldReturnTrueForPastDate()
    {
        var pastDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));

        var result = pastDate.IsInThePast();

        Assert.True(result);
    }

    [Fact]
    public void IsInThePast_ShouldReturnFalseForTodayOrFutureDate()
    {
        var todayDate = DateOnly.FromDateTime(DateTime.Today);
        var futureDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

        Assert.False(todayDate.IsInThePast());
        Assert.False(futureDate.IsInThePast());
    }

    [Fact]
    public void IsInThePast_ShouldReturnFalseForNullDate()
    {
        DateOnly? dateOnly = null;

        var result = dateOnly.IsInThePast();

        Assert.False(result);
    }
}