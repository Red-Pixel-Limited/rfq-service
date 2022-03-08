namespace RFQ.Core.Options
{
    using System;

    [Flags]
    [Serializable]
    public enum Error
    {
        Arithmetic = 0x1,
        Communication = 0x2,
        Runtime = 0x3,
        Configuration = 0x4,
        Validation = 0x5
    }
}
