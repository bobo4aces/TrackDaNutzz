using System;
using TrackDaNutzz.Services.Common.Enums;
using TrackDaNutzz.Services.Extensions;
using Xunit;

namespace TrackDaNutzz.Tests.TrackDaNutzz.Services.Tests
{
    public class ExtensionsTests
    {
        //DateTime Before(this DateTime date, TimePeriod timePeriod, int timePeriodCount)
        [Fact]
        public void TestBefore_WithOneDayBefore_ShouldReturnOneDateBefore()
        {
            DateTime date = new DateTime(2019, 8, 3);

            DateTime dayBeforeDate = date.Before(TimePeriod.Day,-1);

            DateTime expected = new DateTime(2019, 8, 2);
            DateTime actual = dayBeforeDate;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestBefore_WithOneMonthBefore_ShouldReturnOneMonthBefore()
        {
            DateTime date = new DateTime(2019, 8, 3);

            DateTime dayBeforeDate = date.Before(TimePeriod.Month, -1);

            DateTime expected = new DateTime(2019, 7, 3);
            DateTime actual = dayBeforeDate;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestBefore_WithOneYearBefore_ShouldReturnOneYearBefore()
        {
            DateTime date = new DateTime(2019, 8, 3);

            DateTime dayBeforeDate = date.Before(TimePeriod.Year, -1);

            DateTime expected = new DateTime(2018, 8, 3);
            DateTime actual = dayBeforeDate;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestBefore_WithOneYearBeforeAndInvalidYear_ShouldThrowArgumentOutOfRangeException()
        {
            DateTime date = new DateTime();

            Assert.Throws(typeof(ArgumentOutOfRangeException), () => date.Before(TimePeriod.Year, -1));
        }
    }
}
