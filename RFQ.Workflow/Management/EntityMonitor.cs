namespace RFQ.Workflow.Management
{
    using System;
    using System.Timers;
    using Core.Entities;
    using Core.Management;
    using Core.Options;
    using Utils;

    internal abstract class EntityMonitor<TEntity> : IMonitor
        where TEntity : ITrackable
    {
        private bool _isDisposed;
        private TimeSpan _aliveTill;
        private readonly TEntity _entity;
        private readonly Timer _monitoringTimer;

        public bool Started { get; private set; }
        public DateTime StartedAt { get; private set; }
        public TEntity Trackable { get { return _entity; } }

        internal EntityMonitor(TEntity entity)
        {
            _entity = entity;
            _monitoringTimer = new Timer();
            _monitoringTimer.Elapsed += IntervalElapsed;
        }

        ~EntityMonitor()
        {
            Dispose(false);
        }

        public void Start(long expiresAfter)
        {
            Start(expiresAfter, 0L);
        }

        public void Start(long expiresAfter, long syncAfter)
        {
            if (!Started)
            {
                _aliveTill = expiresAfter.Milliseconds();
                _monitoringTimer.Interval = syncAfter > 0 ? syncAfter : expiresAfter;
                _monitoringTimer.Start();
                _entity.Visit(Reason.Initiated);
                StartedAt = DateTime.UtcNow;
                Started = true;
            }
        }

        public TimeSpan GetRemainingTime()
        {
            if (!Started)
                return TimeSpan.Zero;

            var howMuchTimePassedFromStart = DateTime.UtcNow.Subtract(StartedAt);

            if (_aliveTill.CompareTo(howMuchTimePassedFromStart) <= 0) 
                return TimeSpan.Zero;

            var remainingTime = _aliveTill.Subtract(howMuchTimePassedFromStart);
            return remainingTime;
        }

        public void Cancel()
        {
            if (Started)
            {
                _monitoringTimer.Stop();
                _entity.Visit(Reason.Cancelled);
                Started = false;
            }
        }

        private void IntervalElapsed(object sender, ElapsedEventArgs args)
        {
            var remainingTime = GetRemainingTime();

            if (remainingTime.CompareTo(TimeSpan.Zero) <= 0)
            {
                _monitoringTimer.Stop();
                _entity.Visit(Reason.Expires);
                SendExpiryAlert();
                Started = false;
                return;
            }

            if (remainingTime.TotalMilliseconds <= _monitoringTimer.Interval)
                _monitoringTimer.Interval = remainingTime.TotalMilliseconds;

            SendSyncRequest();
        }

        protected virtual void SendSyncRequest() {}
        protected abstract void SendExpiryAlert();

        #region IDisposable Members

        protected void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                _monitoringTimer.Elapsed -= IntervalElapsed;
                _monitoringTimer.Dispose();
            }

            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
