namespace RFQ.Communication.Messages.Incoming
{
    public sealed class DetectWhetherMarketMaker : CommunicationMessage
    {
        public string OrganizationId { get; private set; }

        public DetectWhetherMarketMaker(string requestId, string organizationId)
            : base(requestId)
        {
            OrganizationId = organizationId;
        }
    }
}
