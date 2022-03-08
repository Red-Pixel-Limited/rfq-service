namespace RFQ.Communication.Messages.Incoming
{
    public abstract class GTNEvent : InstanceMessage
    {
        protected GTNEvent(string requestId, string venueId, string productId, string instanceId) 
            : base(requestId, venueId, productId, instanceId) {}
    }
}
