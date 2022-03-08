namespace RFQ.Communication.DTOs
{
    using Artifacts;

    public sealed class BrokerConfigurationDTO
    {
        public string VenueId { get; private set; }
        public string ProductId { get; private set; }
        public bool CanAutoConnect { get; private set; }
        public IBUserCredentials PasswordCredentials { get; private set; }

        public BrokerConfigurationDTO(string venueId,
                                      string productId,
                                      bool canAutoConnect,
                                      IBUserCredentials passwordCredentials)
        {
            PasswordCredentials = passwordCredentials;
            CanAutoConnect = canAutoConnect;
            ProductId = productId;
            VenueId = venueId;
        }
    }
}
