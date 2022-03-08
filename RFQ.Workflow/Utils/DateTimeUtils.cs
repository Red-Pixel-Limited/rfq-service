namespace RFQ.Workflow.Utils
{
    using System;

    static class DateTimeUtils
    {
        private static DateTime UnixEpoch { get { return new DateTime(1970, 1, 1, 0, 0, 0); } }

        internal static long ToUnixTimestamp(this DateTime utcDateTime)
        {
            return (long)(utcDateTime.Subtract(UnixEpoch)).TotalSeconds;
        }

        internal static DateTime ToDateTime(this long unixTimestamp)
        {
            return UnixEpoch.AddSeconds(unixTimestamp);
        }

        internal static TimeSpan Milliseconds(this long value)
        {
            return TimeSpan.FromMilliseconds(value);
        }
    }
}
