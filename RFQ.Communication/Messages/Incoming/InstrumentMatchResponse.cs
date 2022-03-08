namespace RFQ.Communication.Messages.Incoming
{
    public sealed class InstrumentMatchResponse : ProductVenueMessage
    {
        public string InstrumentId { get; private set; }
        public bool Matched { get; private set; }

        public InstrumentMatchResponse(string requestId,
                                       string venueId,
                                       string productId,
                                       string instrumentId,
                                       bool matched)
            : base(requestId, venueId, productId)
        {
            InstrumentId = instrumentId;
            Matched = matched;
        }
    }
}
