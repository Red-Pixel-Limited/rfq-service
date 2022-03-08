namespace RFQ.Communication.Messages.Incoming
{
    public sealed class StartBrokerSession : ProductVenueMessage
    {
        public StartBrokerSession(string requestId, string venueId, string productId)
            : base(requestId, venueId, productId) {}
    }
}
