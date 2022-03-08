namespace RFQ.Communication.Messages.Incoming
{
    public sealed class RespondInstrumentConfiguration : InstanceMessage
    {
        public string InstrumentId { get; private set; }
        public string GTNUserSessionId { get; private set; }
        public bool ShouldIncludeOrganizations { get; private set; }

        public RespondInstrumentConfiguration(string requestId,
                                       string venueId,
                                       string productId,
                                       string instanceId,
                                       string instrumentId,
                                       string gtnUserSessionId,
                                       bool includeOrganizations)
            : base(requestId, venueId, productId, instanceId)
        {
            InstrumentId = instrumentId;
            GTNUserSessionId = gtnUserSessionId;
            ShouldIncludeOrganizations = includeOrganizations;
        }
    }
}
