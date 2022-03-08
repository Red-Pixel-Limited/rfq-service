namespace RFQ.Communication.Messages.Incoming
{
    public sealed class StopBrokerSession : ProductVenueMessage
    {
        public StopBrokerSession(string requestId, string venueId, string productId)
            : base(requestId, venueId, productId) {}
    }
}
