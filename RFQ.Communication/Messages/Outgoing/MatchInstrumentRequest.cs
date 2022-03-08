namespace RFQ.Communication.Messages.Outgoing
{
    using DTOs;
    using System.Collections.Generic;

    public sealed class MatchInstrumentRequest : ProductVenueMessage
    {
        public string InstrumentId { get; private set; }
        public IList<InstrumentAttributeDTO> Attributes { get; private set; }

        public MatchInstrumentRequest(string requestId,
                                      string venueId,
                                      string productId,
                                      string instrumentId,
                                      IList<InstrumentAttributeDTO> attributes)
            : base(requestId, venueId, productId)
        {
            InstrumentId = instrumentId;
            Attributes = attributes;
        }
    }
}
