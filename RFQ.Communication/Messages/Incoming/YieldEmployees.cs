namespace RFQ.Communication.Messages.Incoming
{
    public sealed class YieldEmployees : ProductVenueMessage
    {
        public string OrganizationId { get; private set; }

        public YieldEmployees(string requestId,
                              string venueId,
                              string productId,
                              string organizationId)
            : base(requestId, venueId, productId)
        {
            OrganizationId = organizationId;
        }
    }
}
