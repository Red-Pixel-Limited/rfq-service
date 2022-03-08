namespace RFQ.Communication.Messages.Outgoing
{
    public sealed class QuoteActionFailed : InstanceMessage
    {
        public string QuoteId { get; private set; }
        public string RFQId { get; private set; }
        public string OwnerGTNSessionId { get; private set; }
        public int ErrorCode { get; private set; }
        public string Reason { get; private set; }

        public QuoteActionFailed(string requestId,
                                 string venueId,
                                 string productId,
                                 string instanceId,
                                 string quoteId,
                                 string rfqId,
                                 string ownerGTNSessionId,
                                 int errorCode,
                                 string reason)
            : base(requestId, venueId, productId, instanceId)
        {
            QuoteId = quoteId;
            RFQId = rfqId;
            OwnerGTNSessionId = ownerGTNSessionId;
            ErrorCode = errorCode;
            Reason = reason;
        }
    }
}
