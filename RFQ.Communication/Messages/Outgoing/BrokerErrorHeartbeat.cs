namespace RFQ.Communication.Messages.Outgoing
{
    using Options;

    public class BrokerErrorHeartbeat : BrokerHeartbeat
    {
        public int ErrorCode { get; private set; }
        public string Reason { get; private set; }

        public BrokerErrorHeartbeat(string displayName,
                                    int heartbeatInterval,
                                    GRSPStatus status,
                                    int errorCode,
                                    string reason,
                                    string venueId,
                                    string productId,
                                    string requestId = "")
            : base(displayName, heartbeatInterval, status, venueId, productId, requestId)
        {
            ErrorCode = errorCode;
            Reason = reason;
        }
    }
}
