namespace RFQ.Communication.Messages.Outgoing
{
    using System.Collections.Generic;
    using DTOs;

    public sealed class RequestedInstrumentConfigurations : ProductVenueMessage
    {
        public IList<InstrumentConfigurationDTO> Configurations { get; private set; }
 
        public RequestedInstrumentConfigurations(string requestId, 
                                                 string venueId, 
                                                 string productId, 
                                                 IList<InstrumentConfigurationDTO> configurations) 
            : base(requestId, venueId, productId)
        {
            Configurations = configurations;
        }
    }
}
