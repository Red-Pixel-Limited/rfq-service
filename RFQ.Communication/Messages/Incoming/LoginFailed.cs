namespace RFQ.Communication.Messages.Incoming
{
    public sealed class LoginFailed : GTNErrorEvent
    {
        public LoginFailed(string requestId, 
                           string venueId, 
                           string productId, 
                           string instanceId, 
                           string reason, 
                           int errorCode) 
            : base(requestId, venueId, productId, instanceId, reason, errorCode) {}
    }
}
