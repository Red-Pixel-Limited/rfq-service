namespace RFQ.Communication.Options
{
    using System;

    [Flags]
    public enum Side
    {
        Undefined = -1,
        Buy = 0,
        Sell = 1,
        Both = 2
    }
}
