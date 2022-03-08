namespace RFQ.Communication.Messages.Incoming
{
    using DTOs;

    public sealed class GTNUserSessionCreated : GTNSuccessEvent
    {
        public GTNUserSessionCreated(string requestId, 
                                     string venueId, 
                                     string productId, 
                                     string instanceId, 
                                     GTNUserSessionDTO details)
            : base(requestId, venueId, productId, instanceId, details) {}
    }
}
