namespace RFQ.Communication.Messages.Outgoing
{
    public sealed class RFQActionSucceeded : InstanceMessage
    {
        public string RFQId { get; private set; }
        public string GTNUserSessionId { get; private set; }

        public RFQActionSucceeded(string requestId,
                                  string venueId,
                                  string productId,
                                  string instanceId,
                                  string rfqId,
                                  string gtnUserSessionId)
            : base(requestId, venueId, productId, instanceId)
        {
            RFQId = rfqId;
            GTNUserSessionId = gtnUserSessionId;
        }
    }
}
