namespace RFQ.Communication.Messages.Incoming
{
    public sealed class GTNUserSessionDisconnected : GTNErrorEvent
    {
        public GTNUserSessionDisconnected(string requestId, 
                                          string venueId, 
                                          string productId, 
                                          string instanceId,
                                          string gtnUserSessionId,
                                          string reason, 
                                          int errorCode) 
            : base(requestId, venueId, productId, instanceId, reason, errorCode, gtnUserSessionId) {}
    }
}
