namespace RFQ.Communication.Messages.Outgoing
{
    public sealed class CreateGTNSessionRequest : InstanceMessage
    {
        public object Credentials { get; private set; }

        public CreateGTNSessionRequest(string requestId,
                                       string venueId,
                                       string productId,
                                       string instanceId,
                                       object credentials)
            : base(requestId, venueId, productId, instanceId)
        {
            Credentials = credentials;
        }
    }
}
