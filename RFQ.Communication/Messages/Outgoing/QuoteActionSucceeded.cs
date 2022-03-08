namespace RFQ.Communication.Messages.Outgoing
{
    public sealed class QuoteActionSucceeded : InstanceMessage
    {
        public string QuoteId { get; private set; }
        public string RFQId { get; private set; }
        public string OwnerGTNSessionId { get; private set; }

        public QuoteActionSucceeded(string requestId,
                                    string venueId,
                                    string productId,
                                    string instanceId,
                                    string quoteId,
                                    string rfqId,
                                    string gtnSessionId)
            : base(requestId, venueId, productId, instanceId)
        {
            QuoteId = quoteId;
            RFQId = rfqId;
            OwnerGTNSessionId = gtnSessionId;
        }
    }
}
