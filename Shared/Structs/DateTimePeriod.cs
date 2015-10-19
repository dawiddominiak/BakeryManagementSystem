using System;

namespace Shared.Structs
{
    /// <summary>
    /// DateTimePeriod object. Mutable struct representing constant 
    /// (from DateTime to DateTime) time period.
    /// </summary>
    public struct DateTimePeriod : IEquatable<DateTimePeriod>
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public DateTimePeriod(DateTime from, DateTime to) : this()
        {
            //TODO: check correct
            From = from;
            To = to;
        }

        public DateTimePeriod(DateTime from, TimeSpan span) : this()
        {
            From = from;
            To = from + span;
        }

        public bool IsIncluded(DateTime dateTime)
        {
            return dateTime.CompareTo(From) >= 0 && dateTime.CompareTo(To) < 0;
        }

        public bool Equals(DateTimePeriod other)
        {
            return From == other.From &&
                   To == other.To;
        }
    }
}