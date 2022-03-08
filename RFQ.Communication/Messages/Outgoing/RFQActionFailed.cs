namespace RFQ.Communication.Messages.Outgoing
{
    public sealed class RFQActionFailed : InstanceMessage
    {
        public string RFQId { get; private set; }
        public string GTNUserSessionId { get; private set; }
        public int ErrorCode { get; private set; }
        public string Reason { get; private set; }

        public RFQActionFailed(string requestId,
                               string venueId,
                               string productId,
                               string instanceId,
                               string rfqId,
                               string gtnUserSessionId,
                               int errorCode,
                               string reason)
            : base(requestId, venueId, productId, instanceId)
        {
            Reason = reason;
            ErrorCode = errorCode;
            RFQId = rfqId;
            GTNUserSessionId = gtnUserSessionId;
        }
    }
}
