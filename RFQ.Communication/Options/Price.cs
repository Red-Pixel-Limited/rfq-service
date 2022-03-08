namespace RFQ.Communication.Options
{
    using System;

    [Flags]
    public enum Price
    {
        Undefined = -1,
        CashPrice = 0,
        Yield = 1,
        YieldDifference = 2,
        Basis = 3,
        Spread = 4
    }
}
