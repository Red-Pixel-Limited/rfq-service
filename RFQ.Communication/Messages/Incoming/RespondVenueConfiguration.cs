namespace RFQ.Communication.Messages.Incoming
{
    public sealed class RespondVenueConfiguration : ProductVenueMessage
    {
        public RespondVenueConfiguration(string requestId, string venueId, string productId)
            : base(requestId, venueId, productId) {}
    }
}
