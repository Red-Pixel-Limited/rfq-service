namespace RFQ.Communication.Options
{
    using System;

    [Flags]
    public enum PricePriority
    {
        Undefined = -1,
        HigherIsBetter = 0,
        LowerIsBetter = 1
    }
}
