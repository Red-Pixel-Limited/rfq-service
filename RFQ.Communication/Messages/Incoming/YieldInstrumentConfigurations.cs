namespace RFQ.Communication.Messages.Incoming
{
    public sealed class YieldInstrumentConfigurations : ProductVenueMessage
    {
        public YieldInstrumentConfigurations(string requestId, string venueId, string productId) 
            : base(requestId, venueId, productId) {}
    }
}
