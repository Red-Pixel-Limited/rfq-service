namespace RFQ.Communication.Messages.Outgoing
{
    public sealed class GTNHeartbeatsSubscription : CommunicationMessage
    {
        public GTNHeartbeatsSubscription(string requestId)
            : base(requestId)
        {
        }
    }
}
