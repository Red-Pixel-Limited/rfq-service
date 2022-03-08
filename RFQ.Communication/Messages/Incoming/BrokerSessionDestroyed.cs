namespace RFQ.Communication.Messages.Incoming
{
    public sealed class BrokerSessionDestroyed : InstanceMessage
    {
        public string BrokerSessionId { get; private set; }

        public BrokerSessionDestroyed(string requestId,
                                      string venueId,
                                      string productId,
                                      string instanceId,
                                      string brokerSessionId)
            : base(requestId, venueId, productId, instanceId)
        {
            BrokerSessionId = brokerSessionId;
        }
    }
}
