namespace RFQ.Communication.Messages.Incoming
{
    using DTOs;
    using Options;
    using System.Collections.Generic;

    public sealed class NewRFQ : InstanceMessage
    {
        public Side Side { get; private set; }
        public long Size { get; private set; }
        public long SizeBase { get; private set; }
        public bool TradedByVWAP { get; private set; }
        public long RequestTimer { get; private set; }
        public string InstrumentId { get; private set; }
        public string InstrumentName { get; private set; }
        public string GTNUserSessionId { get; private set; }
        public IList<OrganizationDTO> Organizations { get; private set; }

        public NewRFQ(string requestId,
                      string venueId,
                      string productId,
                      string instanceId,
                      Side side,
                      long size,
                      long sizeBase,
                      bool tradedByVWAP,
                      long requestTimer,
                      string instrumentId,
                      string instrumentName,
                      string gtnUserSessionId,
                      IList<OrganizationDTO> organizations)
            : base(requestId, venueId, productId, instanceId)
        {
            Side = side;
            Size = size;
            SizeBase = sizeBase;
            TradedByVWAP = tradedByVWAP;
            RequestTimer = requestTimer;
            InstrumentId = instrumentId;
            InstrumentName = instrumentName;
            GTNUserSessionId = gtnUserSessionId;
            Organizations = organizations;
        }
    }
}
