namespace RFQ.Communication.Messages.Incoming
{
    using DTOs;

    public sealed class StoreInstrumentConfiguration : ProductVenueMessage
    {
        public string Username { get; private set; }
        public InstrumentConfigurationDTO Configuration { get; private set; }

        public StoreInstrumentConfiguration(string requestId,
                                            string venueId,
                                            string productId,
                                            string username,
                                            InstrumentConfigurationDTO configuration)
            : base(requestId, venueId, productId)
        {
            Username = username;
            Configuration = configuration;
        }
    }
}
