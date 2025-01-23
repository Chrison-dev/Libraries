namespace System;

// TODO: Move into its own project Chrison.Extensions.TinyHelpers
/// <summary>
/// Extensions for <see cref="TimeOnly"/>"/>
/// </summary>
public static class TimeOnlyExtensions
{
    /// <summary>
    /// Converts <see cref="TimeOnly"/> into <see cref="DateTime"/>
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public static DateTime ToDateTime(this TimeOnly time) => new DateTime(2000, 1, 1) + time.ToTimeSpan();

    /// <summary>
    /// Converts <see cref="TimeOnly"/> into <see cref="DateTime"/>
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public static DateTime? ToDateTime(this TimeOnly? time)
    {
        if (!time.HasValue) return null;
        return time.Value.ToDateTime();
    }
}