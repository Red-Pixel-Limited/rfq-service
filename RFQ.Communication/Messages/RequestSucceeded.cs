namespace RFQ.Communication.Messages
{
    public sealed class RequestSucceeded : InstanceMessage
    {
        public RequestSucceeded(string requestId, string venueId, string productId, string instanceId)
            : base(requestId, venueId, productId, instanceId) {}
    }
}
