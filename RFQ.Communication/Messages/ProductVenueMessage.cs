namespace RFQ.Communication.Messages
{
    public abstract class ProductVenueMessage : CommunicationMessage
    {
        public string VenueId { get; private set; }
        public string ProductId { get; private set; }

        protected ProductVenueMessage(string requestId,
                                      string venueId,
                                      string productId)
            : base(requestId)
        {
            ProductId = productId;
            VenueId = venueId;
        }
    }
}
