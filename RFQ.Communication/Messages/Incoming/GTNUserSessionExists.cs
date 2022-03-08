namespace RFQ.Communication.Messages.Incoming
{
    using DTOs;

    public sealed class GTNUserSessionExists : GTNSuccessEvent
    {
        public GTNUserSessionExists(string requestId, 
                                    string venueId, 
                                    string productId, 
                                    string instanceId, 
                                    GTNUserSessionDTO details) 
            : base(requestId, venueId, productId, instanceId, details) {}
    }
}
