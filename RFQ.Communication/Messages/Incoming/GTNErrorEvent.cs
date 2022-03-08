namespace RFQ.Communication.Messages.Incoming
{
    public abstract class GTNErrorEvent : GTNEvent
    {
        public string GTNUserSessionId { get; private set; }
        public string Reason { get; private set; }
        public int ErrorCode { get; private set; }

        protected GTNErrorEvent(string requestId, 
                                string venueId, 
                                string productId, 
                                string instanceId, 
                                string reason, 
                                int errorCode,
                                string gtnUserSessionId = null)
            : base(requestId, venueId, productId, instanceId)
        {
            GTNUserSessionId = gtnUserSessionId;
            Reason = reason;
            ErrorCode = errorCode;
        }
    }
}
