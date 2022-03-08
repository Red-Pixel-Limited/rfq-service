namespace RFQ.Core.Options
{
    using System;

    [Flags]
    public enum Reason
    {
        Expires = 0x1,
        Cancelled = 0x2,
        Initiated = Expires | Cancelled
    }
}
