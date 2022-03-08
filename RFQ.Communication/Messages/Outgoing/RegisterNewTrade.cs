namespace RFQ.Communication.Messages.Outgoing
{
    using DTOs;
    using System.Collections.Generic;

    public sealed class RegisterNewTrade : InstanceMessage
    {
        public long TradedAt { get; private set; }
        public string InstrumentId { get; private set; }
        public string GTNSessionIdForBroker { get; private set; }
        public IList<TradeParticipantDTO> TradeParticipants { get; private set; }

        public RegisterNewTrade(string requestId,
                                string venueId,
                                string productId,
                                string instanceId,
                                long tradedAt,
                                string instrumentId,
                                string gtnSessionIdForBroker,
                                IList<TradeParticipantDTO> tradeParticipants)
            : base(requestId, venueId, productId, instanceId)
        {
            TradedAt = tradedAt;
            InstrumentId = instrumentId;
            GTNSessionIdForBroker = gtnSessionIdForBroker;
            TradeParticipants = tradeParticipants;
        }
    }
}
