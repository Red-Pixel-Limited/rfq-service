namespace RFQ.Communication.Messages.Incoming
{
    using DTOs;

    public sealed class StoreBrokerConfiguration : ProductVenueMessage
    {
        public BrokerConfigurationDTO Configuration { get; private set; }

        public StoreBrokerConfiguration(string requestId,
                                        string venueId,
                                        string productId,
                                        BrokerConfigurationDTO configuration)
            : base(requestId, venueId, productId)
        {
            Configuration = configuration;
        }
   }
}
