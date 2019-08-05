using System;
using TrackDaNutzz.Services.Common.Enums;

namespace TrackDaNutzz.Services.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime Before(this DateTime date, TimePeriod timePeriod, int timePeriodCount)
        {
            switch (timePeriod)
            {
                case TimePeriod.Day:
                    return date.AddDays(timePeriodCount);
                case TimePeriod.Month:
                    return date.AddMonths(timePeriodCount);
                case TimePeriod.Year:
                    return date.AddYears(timePeriodCount);
                default:
                    throw new ArgumentOutOfRangeException("Invalid date");
            }
        }
    }
}
