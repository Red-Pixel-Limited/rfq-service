namespace RFQ.Communication.Messages
{
    public abstract class InstanceMessage : ProductVenueMessage
    {
        public string InstanceId { get; private set; }

        protected InstanceMessage(string requestId,
                                  string venueId,
                                  string productId,
                                  string instanceId)
            : base(requestId, venueId, productId)
        {
            InstanceId = instanceId;
        }
    }
}
