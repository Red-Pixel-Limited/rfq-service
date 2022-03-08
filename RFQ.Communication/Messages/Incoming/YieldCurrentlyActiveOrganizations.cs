namespace RFQ.Communication.Messages.Incoming
{
    public sealed class YieldCurrentlyActiveOrganizations : ProductVenueMessage
    {
        public YieldCurrentlyActiveOrganizations(string requestId, string venueId, string productId) 
            : base(requestId, venueId, productId) {}
    }
}
