namespace RFQ.Communication.Messages.Outgoing
{
    public sealed class DestroyGTNSessionRequest : InstanceMessage
    {
        public string GTNSessionIdForBroker { get; private set; }

        public DestroyGTNSessionRequest(string requestId,
                                        string venueId,
                                        string productId,
                                        string instanceId,
                                        string gtnSessionIdForBroker)
            : base(requestId, venueId, productId, instanceId)
        {
            GTNSessionIdForBroker = gtnSessionIdForBroker;
        }
    }
}
