namespace RFQ.Communication.Options
{
    using System;

    [Flags]
    public enum UpdateAction
    {
        Unknown = -1,
        Snapshot = 0,
        Refresh = 1,
        Update = 2,
        Remove = 3,
        Add = 4
    }
}
