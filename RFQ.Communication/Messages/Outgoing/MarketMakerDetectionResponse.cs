namespace RFQ.Communication.Messages.Outgoing
{
    public sealed class MarketMakerDetectionResponse : CommunicationMessage
    {
        public string OrganizationId { get; private set; }
        public bool IsMarketMaker { get; private set; }

        public MarketMakerDetectionResponse(string requestId,
                                            string organizationId,
                                            bool isMarketMaker)
            : base(requestId)
        {
            OrganizationId = organizationId;
            IsMarketMaker = isMarketMaker;
        }
    }
}
