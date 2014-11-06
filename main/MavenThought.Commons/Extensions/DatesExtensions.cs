using System;

namespace MavenThought.Commons.Extensions
{
    public static class DatesExtensions
    {
        public static DateTimeBuilder Day(this int number)
        {
            return new DateTimeBuilder(1);
        }
        public static DateTimeBuilder Days(this int number)
        {
            return new DateTimeBuilder(number);
        }
    }

    public class DateTimeBuilder
    {
        private readonly int _number;

        public DateTimeBuilder(int number)
        {
            _number = number;
        }

        public DateTime Ago
        {
            get { return DateTime.Today.AddDays(-_number); }
        }
        public TimeSpan Span
        {
            get { return new TimeSpan(_number); }
        }
    }
}
