using TinyHelpers.Extensions;

namespace System;

// TODO: Move into its own project Chrison.Extensions.TinyHelpers
/// <summary>
/// Extensions for <see cref="DateOnly"/>
/// </summary>
public static class DateOnlyExtensions
{
    /// <summary>
    /// Converts <see cref="DateOnly"/> into <see cref="DateTime"/>
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime ToDateTime(this DateOnly date) => new(date.Year, date.Month, date.Day);

    /// <summary>
    /// Converts nullable <see cref="DateOnly"/> into nullable <see cref="DateTime"/>
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime? ToDateTime(this DateOnly? date) => !date.HasValue ? null : date.Value.ToDateTime();

    /// <summary>
    /// Check whether a Date is in the Future
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static bool IsInTheFuture(this DateOnly date) => date > DateTime.Today.ToDateOnly();

    /// <summary>
    /// Check whether a Date is in the Future
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    /// <remarks>Returns true if Date is null</remarks>
    public static bool IsInTheFuture(this DateOnly? date) => !date.HasValue || date.Value.IsInTheFuture();

    /// <summary>
    /// Check whether a Date is in the Present (Today or in the Future)
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static bool IsInThePresent(this DateOnly date) => date.IsInTheFuture() || date.IsToday();

    /// <summary>
    /// Check whether a Date is in the Present (Today or in the Future)
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static bool IsInThePresent(this DateOnly? date) => !date.HasValue || date.Value.IsInThePresent();

    /// <summary>
    /// Check whether a Date is Today
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static bool IsToday(this DateOnly date) => date == DateTime.Today.ToDateOnly();

    /// <summary>
    /// Check whether a Date is Today
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static bool IsToday(this DateOnly? date) => !date.HasValue || date.Value.IsToday();

    /// <summary>
    /// Check whether a Date is in the Past
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static bool IsInThePast(this DateOnly date) => date < DateTime.Today.ToDateOnly();

    /// <summary>
    /// Check whether a Date is in the Past
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    /// <remarks>Returns false if Date is null</remarks>
    public static bool IsInThePast(this DateOnly? date) => date.HasValue && date.Value.IsInThePast();
}