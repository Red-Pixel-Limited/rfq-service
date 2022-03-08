namespace RFQ.Communication.Messages.Incoming
{
    using DTOs;

    public sealed class NewQuote : InstanceMessage
    {
        public string RFQId { get; private set; }
        public QuoteDTO Quote { get; private set; }
        public string GTNUserSessionId { get; private set; }

        public NewQuote(string requestId,
                        string venueId,
                        string productId,
                        string instanceId,
                        string rfqId,
                        QuoteDTO quote,
                        string gtnUserSessionId)
            : base(requestId, venueId, productId, instanceId)
        {

            RFQId = rfqId;
            Quote = quote;
            GTNUserSessionId = gtnUserSessionId;
        }
    }
}
