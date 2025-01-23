using TinyHelpers.Extensions;

namespace System;

// TODO: Move into its own project Chrison.Extensions.TinyHelpers
/// <summary>
/// Extensions for <see cref="DateTime"/>
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// Substract Months
    /// </summary>
    /// <param name="date"></param>
    /// <param name="months"></param>
    /// <returns></returns>
    public static DateTime SubstractMonths(this DateTime date, int months) => date.AddMonths(months * -1);

    /// <summary>
    /// Substract Days
    /// </summary>
    /// <param name="date"></param>
    /// <param name="days"></param>
    /// <returns></returns>
    public static DateTime SubstractDays(this DateTime date, int days) => date.AddDays(days * -1);

    /// <summary>
    /// Check whether a Date is in the Past
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static bool IsInThePast(this DateTime date) => date < DateTime.Now;

    /// <summary>
    /// Check whether a Date is in the Future
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static bool IsInTheFuture(this DateTime date) => date > DateTime.Now;

    /// <summary>
    /// Check whether a Date is Today
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static bool IsToday(this DateTime date) => date.Year == DateTime.Today.Year && date.Month == DateTime.Today.Month && date.Day == DateTime.Today.Day;

    /// <summary>
    /// Converts <see cref="DateTime"/> into <see cref="DateOnly"/>
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static DateOnly? ToDateOnly(this DateTime? dateTime)
    {
        if (!dateTime.HasValue) return null;
        return dateTime.Value.ToDateOnly();
    }

    /// <summary>
    /// Converts <see cref="DateTime"/> into <see cref="TimeOnly"/>
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static TimeOnly? ToTimeOnly(this DateTime? dateTime)
    {
        if (!dateTime.HasValue) return null;
        return dateTime.Value.ToTimeOnly();
    }
}
