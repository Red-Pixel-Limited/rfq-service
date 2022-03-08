namespace RFQ.Communication.Options
{
    using System;

    [Flags]
    public enum PriceFormat
    {
        Undefined = -1,
        TreasuryNote32NDs = 0,
        TreasureNote64THs = 1,
        Whole32NDs = 2,
        Decimals = 3
    }
}
