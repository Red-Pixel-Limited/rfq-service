namespace RFQ.Communication.Messages.Outgoing
{
    using DTOs;
    using Options;
    using System;

    public sealed class StatusUpdateForQuote : InstanceMessage
    {
        public string QuoteId { get; private set; }
        public QuoteDTO Quote { get; private set; }
        public QuoteState CurrentState { get; private set; }
        public string RFQId { get; private set; }
        public bool IsBestBuyQuote { get; private set; }
        public bool IsBestSellQuote { get; private set; }
        public DateTime SubmittedAt { get; private set; }
        public OrganizationDTO SubmittedByOrg { get; private set; }
        public string SubmittedByUser { get; private set; }
        public string MarketMakerGTNSessionId { get; private set; }
        public UpdateAction UpdateAction { get; private set; }
        public bool IsSnapshot { get; private set; }

        public StatusUpdateForQuote(string requestId,
                                    string venueId,
                                    string productId,
                                    string instanceId,
                                    string quoteId,
                                    QuoteDTO quote,
                                    QuoteState currentState,
                                    string rfqId,
                                    bool isBestBuyQuote,
                                    bool isBestSellQuote,
                                    DateTime submittedAt,
                                    OrganizationDTO submittedByOrg,
                                    string submittedByUser,
                                    string gtnSessionId,
                                    UpdateAction updateAction,
                                    bool isSnapshot)
            : base(requestId, venueId, productId, instanceId)
        {
            QuoteId = quoteId;
            Quote = quote;
            CurrentState = currentState;
            RFQId = rfqId;
            IsBestBuyQuote = isBestBuyQuote;
            IsBestSellQuote = isBestSellQuote;
            SubmittedAt = submittedAt;
            SubmittedByOrg = submittedByOrg;
            SubmittedByUser = submittedByUser;
            MarketMakerGTNSessionId = gtnSessionId;
            UpdateAction = updateAction;
            IsSnapshot = isSnapshot;
        }
    }
}
