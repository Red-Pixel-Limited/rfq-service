namespace RFQ.Communication.Messages
{
    public sealed class RequestFailed : InstanceMessage
    {
        public string Reason { get; private set; }
        public string ErrorCode { get; private set; }

        public RequestFailed(string requestId,
                             string venueId,
                             string productId,
                             string instanceId,
                             string reason,
                             string errorCode)
            : base(requestId, venueId, productId, instanceId)
        {
            Reason = reason;
            ErrorCode = errorCode;
        }
    }
}
