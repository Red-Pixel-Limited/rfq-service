namespace RFQ.Repository.Specs.Comparers
{
    using System;
    using System.Collections;

    public class DateTimeComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {
            if (!(x is DateTime) || !(y is DateTime))
                return false;

            var dateTime1 = (DateTime)x;
            var dateTime2 = (DateTime)y;

            return dateTime1.Subtract(dateTime2).Seconds == 0;
        }

        public int GetHashCode(object obj)
        {
            return obj == null ? 0 : obj.GetHashCode();
        }
    }
}
