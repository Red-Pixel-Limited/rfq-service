namespace RFQ.Communication.Messages.Incoming
{
    public sealed class CancelRFQ : InstanceMessage
    {
        public string RFQId { get; private set; }
        public string GTNUserSessionId { get; private set; }

        public CancelRFQ(string requestId,
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
