using System;
using System.Collections.Generic;
using Shared;

namespace Domain.Workday
{
    public sealed class Date : IValueObject<Date>
    {
        public int Day { get; private set; }
        public Month Month { get; private set; }
        public int Year { get; private set; }

        public Date(int day, Month month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public int GetMonthNumber()
        {   
            var dictionary = new Dictionary<Month, int>()
            {
                {
                    Month.January, 1
                },
                {
                    Month.February, 2
                },
                {
                    Month.March, 3
                },
                {
                    Month.April, 4
                },
                {
                    Month.May, 5
                },
                {
                    Month.June, 6
                },
                {
                    Month.July, 7
                },
                {
                    Month.August, 8
                },
                {
                    Month.September, 9
                },
                {
                    Month.October, 10
                },
                {
                    Month.November, 11
                },
                {
                    Month.December, 12
                }
            };

            int month;

            if (!dictionary.TryGetValue(Month, out month))
            {
                throw new ArgumentNullException("Month", "Incorrect month specified.");
            }

            return month;
        }

        public override string ToString()
        {
            return Day + "-" + GetMonthNumber() + "-" + Year;
        }

        public bool SameValueAs(Date other)
        {
            return Day == other.Day && Month == other.Month && Year == other.Year;
        }
    }
}
