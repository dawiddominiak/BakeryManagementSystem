using System;
using System.Collections.Generic;

namespace Domain.Workday
{
    public struct Date : IEquatable<Date>
    {
        public int Day { get; private set; }
        public Month Month { get; private set; }
        public int Year { get; private set; }

        public Date(int day, Month month, int year) : this()
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public static Date FromNative(int day, string monthString, int year)
        {
            Month month;
            Month.TryParse(monthString, out month);
         
            return new Date(day, month, year);
        }

        public static Date FromNative(int day, int monthNumber, int year)
        {
            var months = new Dictionary<int, Month>
            {
                {1, Month.January},
                {2, Month.February},
                {3, Month.March},
                {4, Month.April},
                {5, Month.May},
                {6, Month.June},
                {7, Month.July},
                {8, Month.August},
                {9, Month.September},
                {10, Month.October},
                {11, Month.November},
                {12, Month.December}
            };

            Month month;
            months.TryGetValue(monthNumber, out month);

            return new Date(day, month, year);
        }

        public static Date FromNativeDateTime(DateTime dateTime)
        {
            return FromNative(dateTime.Day, dateTime.Month, dateTime.Year);
        }

        public override string ToString()
        {
            return Day + "-" + Month.ToString() + "-" + Year;
        }

        bool IEquatable<Date>.Equals(Date other)
        {
            return Day == other.Day && Month == other.Month && Year == other.Year;
        }
    }
}
