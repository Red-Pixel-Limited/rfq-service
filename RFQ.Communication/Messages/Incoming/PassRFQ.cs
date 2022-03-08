namespace RFQ.Communication.Messages.Incoming
{
    public sealed class PassRFQ : ProductVenueMessage
    {
        public string RFQId { get; private set; }
        public string RequestOwnerId { get; private set; }
        public string InstrumentId { get; private set; }

        public PassRFQ(string requestId,
                       string venueId,
                       string productId,
                       string instrumentId,
                       string rfqId,
                       string requestOwnerId)
            : base(requestId, venueId, productId)
        {
            RFQId = rfqId;
            RequestOwnerId = requestOwnerId;
            InstrumentId = instrumentId;
        }
    }
}
