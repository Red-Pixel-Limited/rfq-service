namespace RFQ.Communication.Messages.Incoming
{
    public sealed class GTNRequestFailed : GTNErrorEvent
    {
        public GTNRequestFailed(string requestId, 
                                string venueId, 
                                string productId, 
                                string instanceId, 
                                string reason, 
                                int errorCode) 
            : base(requestId, venueId, productId, instanceId, reason, errorCode) {}
    }
}
