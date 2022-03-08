namespace RFQ.Communication.Messages.Incoming
{
    using Options;

    public sealed class AcceptQuote : InstanceMessage
    {
        public Side Side { get; private set; }
        public string RFQId { get; private set; }
        public string QuoteId { get; private set; }
        public string GTNUserSessionId { get; private set; }

        public AcceptQuote(string requestId,
                           string venueId,
                           string productId,
                           string instanceId,
                           string quoteId,
                           string rfqId,
                           string gtnUserSessionId,
                           Side side)
            : base(requestId, venueId, productId, instanceId)
        {
            GTNUserSessionId = gtnUserSessionId;
            QuoteId = quoteId;
            RFQId = rfqId;
            Side = side;
        }
    }
}
