namespace RFQ.Communication.Messages.Incoming
{
    public sealed class YieldOrganizationAdjustments : ProductVenueMessage
    {
        public string RuleName { get; private set; }

        public YieldOrganizationAdjustments(string requestId,
                                            string venueId,
                                            string productId,
                                            string ruleName)
            : base(requestId, venueId, productId)
        {
            RuleName = ruleName;
        }
    }
}
