namespace RFQ.Communication.Options
{
    using System;

    [Flags]
    public enum QuoteState
    {
        Unknown = -1,
        Open = 0,
        Cancelled = 1,
        Expired = 2,
        Filled = 3,
        Traded = 4,
        Refused = 5,
        Passed = 6
    }
}
