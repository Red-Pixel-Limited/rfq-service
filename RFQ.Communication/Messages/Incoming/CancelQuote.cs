namespace RFQ.Communication.Messages.Incoming
{
    public sealed class CancelQuote : InstanceMessage
    {
        public string QuoteId { get; private set; }
        public string RFQId { get; private set; }
        public string GTNUserSessionId { get; private set; }

        public CancelQuote(string requestId,
                           string venueId,
                           string productId,
                           string instanceId,
                           string quoteId,
                           string rfqId,
                           string gtnUserSessionId)
            : base(requestId, venueId, productId, instanceId)
        {
            GTNUserSessionId = gtnUserSessionId;
            QuoteId = quoteId;
            RFQId = rfqId;
        }
    }
}
