namespace RFQ.Communication.Options
{
    using System;

    [Flags]
    public enum SizeMagnitude
    {
        Undefined = -1,
        Units = 0,
        Thousands = 1,
        Millions = 2,
        Billions = 3
    }
}
