namespace RFQ.Workflow.Sessions
{
    using System;
    using Artifacts;
    using Communication.Artifacts;
    using Communication.Options;

    public sealed class IBBrokerSession
    {
        private bool _isForceClosed;
        private readonly bool _canAutoConnect;
        private DateTime _lastConnectionAttempt;

        public string VenueId { get; private set; }
        public string ProductId { get; private set; }
        public string DisplayName { get; private set; }
        public object Credentials { get; private set; }
        public GRSPStatus Status { get; private set; }

        public event BrokerConnectEventHander Connecting;

        private IBBrokerSession(BrokerConfiguration configuration)
        {
            _isForceClosed = false;
            _canAutoConnect = configuration.CanAutoConnect;
            VenueId = configuration.VenueId;
            ProductId = configuration.ProductId;
            DisplayName = configuration.DisplayName;
            Credentials = configuration.Credentials;
            Status = GRSPStatus.Stopped;
        }

        public static IBBrokerSession CreateFrom(BrokerConfiguration configuration)
        {
            return new IBBrokerSession(configuration);
        }

        public void AutoConnect()
        {
            _lastConnectionAttempt = DateTime.UtcNow;
            if (!_canAutoConnect || Status == GRSPStatus.Started || _isForceClosed)
                return;
            OnConnect(this);
            Status = GRSPStatus.Started;
        }

        public bool ForceConnect()
        {
            return true;
        }

        #region Event Invocators
        private void OnConnect(IBBrokerSession session)
        {
            var handler = Connecting;
            if (handler != null) handler(session);
        }
        #endregion
    }
}
