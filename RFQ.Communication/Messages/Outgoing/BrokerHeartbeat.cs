namespace RFQ.Communication.Messages.Outgoing
{
    using Options;

    public class BrokerHeartbeat : ProductVenueMessage
    {
        public string DisplayName { get; private set; }
        public int HeartbeatInterval { get; private set; }
        public GRSPStatus Status { get; private set; }

        public BrokerHeartbeat(string displayName,
                               int heartbeatInterval,
                               GRSPStatus status,
                               string venueId,
                               string productId,
                               string requestId = "")
            : base(requestId, venueId, productId)
        {
            Status = status;
            DisplayName = displayName;
            HeartbeatInterval = heartbeatInterval;
        }
    }
}
