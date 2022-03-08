namespace RFQ.Communication.Options
{
    using System;

    [Flags]
    public enum RFQState
    {
        Unknown = -1,
        Open = 0,
        Cancelled = 1,
        Expired = 2
    }
}
