namespace RFQ.Communication.Options
{
    using System;

    [Flags]
    public enum GTNUserSessionStatus
    {
        Unknown = -1,
        Connected = 0,
        Disconnected = 1,
        Destroyed = 2
    }
}
