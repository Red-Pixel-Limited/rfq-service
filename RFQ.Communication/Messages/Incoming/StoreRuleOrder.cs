namespace RFQ.Communication.Messages.Incoming
{
    using System.Collections.Generic;
    using DTOs;

    public sealed class StoreRuleOrder : CommunicationMessage
    {
        public string VenueId { get; private set; }
        public string AssetClass { get; private set; }
        public string UserName { get; private set; }
        public IList<InstrumentConfigurationDTO> Configurations { get; private set; }

        public StoreRuleOrder(string requestId,
                              string venueId,
                              string userName,
                              string assetClass,
                              IList<InstrumentConfigurationDTO> configurations)
            : base(requestId)
        {
            VenueId = venueId;
            UserName = userName;
            AssetClass = assetClass;
            Configurations = configurations;
        }
    }
}
