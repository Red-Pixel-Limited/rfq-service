namespace RFQ.Communication.Messages.Incoming
{
    using DTOs;

    public abstract class GTNSuccessEvent : GTNEvent
    {
        public GTNUserSessionDTO UserSessionDetails { get; private set; }

        protected GTNSuccessEvent(string requestId, 
                                  string venueId, 
                                  string productId, 
                                  string instanceId, 
                                  GTNUserSessionDTO userSessionDetails)
            : base(requestId, venueId, productId, instanceId)
        {
            UserSessionDetails = userSessionDetails;
        }
    }
}
