namespace RFQ.Repository.Specs.Comparers
{
    using System;
    using System.Collections;

    public class NullableDateTimeComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {
            var a = x as DateTime?;
            var b = y as DateTime?;

            if (a == null && b == null)
                return true;

            if (a == null || b == null)
                return false;

            return a.Value.Subtract(b.Value).Seconds == 0;
        }

        public int GetHashCode(object obj)
        {
            return obj == null ? 0 : obj.GetHashCode();
        }
    }
}