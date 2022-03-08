namespace RFQ.Communication.Messages.Incoming
{
    using DTOs;

    public sealed class InstrumentStaticDataResponse : InstanceMessage
    {
        public string RFQId { get; private set; }
        public string InstrumentId { get; private set; }
        public InstrumentStaticDataDTO Instrument { get; private set; }

        public InstrumentStaticDataResponse(string requestId,
                                            string venueId,
                                            string productId,
                                            string instanceId,
                                            string rfqId,
                                            string instrumentId,
                                            InstrumentStaticDataDTO instrument)
            : base(requestId, venueId, productId, instanceId)
        {
            RFQId = rfqId;
            InstrumentId = instrumentId;
            Instrument = instrument;
        }
    }
}
