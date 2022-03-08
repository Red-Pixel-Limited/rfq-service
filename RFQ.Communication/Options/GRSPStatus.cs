namespace RFQ.Communication.Options
{
    using System;

    [Flags]
    public enum GRSPStatus
    {
        Unknown = -1,
        Started = 0,
        Attention = 1,
        Stopped = 2
    }
}
