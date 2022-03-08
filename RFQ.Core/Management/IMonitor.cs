namespace RFQ.Core.Management
{
    using System;

    public interface IMonitor : IDisposable
    {
        bool Started { get; }
        void Start(long expiresAfter);
        void Start(long expiresAfter, long syncAfter);
        TimeSpan GetRemainingTime();
        void Cancel();
    }
}
