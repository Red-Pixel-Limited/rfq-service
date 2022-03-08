namespace RFQ.Communication.Messages.Incoming
{
    public sealed class ApplyForRFQ : InstanceMessage
    {
        public string GTNUserSessionId { get; private set; }

        public ApplyForRFQ(string requestId,
                           string venueId,
                           string productId,
                           string instanceId,
                           string gtnUserSessionId)
            : base(requestId, venueId, productId, instanceId)
        {
            GTNUserSessionId = gtnUserSessionId;
        }
    }
}
