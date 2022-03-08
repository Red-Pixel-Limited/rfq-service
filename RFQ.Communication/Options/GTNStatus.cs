namespace RFQ.Communication.Options
{
    using System;

    [Flags]
    public enum GTNStatus
    {
        Unknown = -1,
        Live = 0,
        Attention = 1,
        Closed = 2
    }
}
