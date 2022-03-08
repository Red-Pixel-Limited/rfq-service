namespace RFQ.Communication.Messages.Incoming
{
    using System.Collections.Generic;
    using DTOs;

    public sealed class StoreOrganizationsAdjustment : ProductVenueMessage
    {
        public string ConfigurationName { get; private set; }
        public IList<InstrumentConfigurationDTO> Firms { get; private set; }

        public StoreOrganizationsAdjustment(string requestId,
                                            string venueId,
                                            string productId,
                                            string configurationName,
                                            IList<InstrumentConfigurationDTO> firms)
            : base(requestId, venueId, productId)
        {
            ConfigurationName = configurationName;
            Firms = firms;
        }
    }
}
